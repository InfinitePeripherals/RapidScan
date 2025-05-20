using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Storage.Streams;

// see: https://learn.microsoft.com/en-us/windows/uwp/devices-sensors/gatt-server
namespace BLETest
{
    //===============================================================================================================================
    public interface BLEObserver
    {
        void ScannerListChanged(IReadOnlyList<GattSubscribedClient> activeBLEClients);
        void ScanIn(string deviceID, string barcode);
    }
    //===============================================================================================================================
    public class BLEServer
    {
        GattServiceProvider bleServer;      // This is the BLE Server listenting on UUID

        // The GUIDS to communicate on
        Guid serverUUID = Guid.NewGuid();                                       // Everytime it runs, a new service so can be unique on all
        Guid rislOutUUID = new Guid("00009002-0000-1000-8000-00805f9b34fb");    // RapidScan will listen to this channel for RISL Cards
        Guid barcodeInUUID = new Guid("00009001-0000-1000-8000-00805f9b34fb");  // RapidScan will listen to this channel for Barcodes

        // Thes are the BLE channels we'll barcodes and send RISL Cards
        GattLocalCharacteristic rislOutService;    // this is where we will send RISL cards (server -> Notifies -> scanner(s) with rislOutCharacteristic
        GattLocalCharacteristic barcodeInService;  // This is where we will read barcodes (scanner -> Writes To -> barcodeInCharacteristic)

        // A list of Connected Clients
        IReadOnlyList<GattSubscribedClient> activeBLEClients = new List<GattSubscribedClient>();         // Start it Empty

        private BLEObserver observer;
        //---------------------------------------------------------------------------------------------------------------------------------------
        private BLEServer() { } 
        public BLEServer( BLEObserver x)
        {
            observer = x;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public async Task Start()
        {
            // Setup the BLE Server
            bleServer = await getBLEServerServiceProvider();
            await AddBarcodeInService();
            await AddRislOutService();

            // Start Listening on this BLE Service
            GattServiceProviderAdvertisingParameters advParameters = new GattServiceProviderAdvertisingParameters{ IsConnectable=true, IsDiscoverable=true };
            bleServer.StartAdvertising(advParameters);  // Server will now listen for ble requests to the serverUUID Channel
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        // We create a Service on the Laptop with a unique UUID.  The unique UUID is if you have 2 laptops etc. in same facility.
        // Otherwise you could use a static UUID
        private async Task<GattServiceProvider> getBLEServerServiceProvider()
        {
            GattServiceProviderResult result = await GattServiceProvider.CreateAsync(serverUUID);
            if (result.Error != BluetoothError.Success) return null;

            bleServer = result.ServiceProvider;
            return bleServer;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        // Now we add some Characteristics to that service
        // Barcode in comes as a write characteristc
        private async Task AddBarcodeInService()
        {
            var writeParameters = new GattLocalCharacteristicParameters();
            writeParameters.CharacteristicProperties = GattCharacteristicProperties.WriteWithoutResponse | GattCharacteristicProperties.Indicate;
            writeParameters.WriteProtectionLevel = GattProtectionLevel.Plain;
            writeParameters.UserDescription = "BarcodeIn";
            var characteristicResult = await bleServer.Service.CreateCharacteristicAsync(barcodeInUUID, writeParameters);
            if (characteristicResult.Error != BluetoothError.Success) return;
            barcodeInService = characteristicResult.Characteristic;
            barcodeInService.WriteRequested += BarcodeIn;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        // Now we add some Characteristics to that service
        // RISL out goes as a notify characteristic
        private async Task AddRislOutService()
        {
            var readParameters = new GattLocalCharacteristicParameters();
            readParameters.CharacteristicProperties = GattCharacteristicProperties.Read | GattCharacteristicProperties.Indicate;
            readParameters.ReadProtectionLevel = GattProtectionLevel.Plain;
            readParameters.UserDescription = "RISLOut";
            var characteristicResult = await bleServer.Service.CreateCharacteristicAsync(rislOutUUID, readParameters);
            if (characteristicResult.Error != BluetoothError.Success) return;
            rislOutService = characteristicResult.Characteristic;
            rislOutService.SubscribedClientsChanged += Notify_ClientsChanged; // Keeps track of the connected clients
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        void Notify_ClientsChanged(GattLocalCharacteristic sender, object args)
        {
            // We keep a list of all clients so we can individual
            // As BLE clients subscribe (or drop) from the RISLOutService, this callback happens
            lock (activeBLEClients)
            {
                IReadOnlyList<GattSubscribedClient> previousClients = activeBLEClients; // Whenever a new list of clients comes in, we can audit versus the old list to send Connected Messages To.
                activeBLEClients = sender.SubscribedClients; // If we need to send only to one etc.

                // We will aduit the previous list versus the new list to see if any new client was added
                // If So: we can send them a "Welcome" Card
                // Note: This isn't always called on client additions, sometimes it is called if client goes away
                foreach(GattSubscribedClient client in activeBLEClients)
                {
                    // If not found in clients then send the client a "Connected Card!" => i.e. just connected
                    bool found = previousClients.Any(prev => prev.Session.DeviceId.Id == client.Session.DeviceId.Id);
                    if (!found) NotifySpecificScanner( GetConnectedRISLCard(client.Session.DeviceId.Id), client.Session.DeviceId);
                }
                observer.ScannerListChanged(activeBLEClients);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        // The Halo Scanner uses the Write Charateristic to Send Barcodes
        async void BarcodeIn(GattLocalCharacteristic sender, GattWriteRequestedEventArgs args)
        {
            var deferral = args.GetDeferral();
            var request = await args.GetRequestAsync();

            // Get the Data 
            var reader = DataReader.FromBuffer(request.Value);
            byte[] buffer = new byte[reader.UnconsumedBufferLength];
            reader.ReadBytes(buffer);
            string barcode = System.Text.Encoding.Default.GetString(buffer);

            // Send the Ack if needed
            if (request.Option == GattWriteOption.WriteWithResponse) request.Respond();            
            deferral.Complete();

            // Run the Biz Logic on a different thread to not tie up incoming
            new Thread( () => {
                observer.ScanIn(args.Session.DeviceId.Id, barcode);  // For the UI Only
                var risl = SomeBusinessLogic(barcode);
                NotifySpecificScanner(risl, args.Session.DeviceId);
            }).Start();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        private void NotifyAllScanners(string msg)
        {
            // If ever desired...
            var writer = new DataWriter();
            writer.ByteOrder = ByteOrder.LittleEndian;
            writer.WriteString(msg);
            IBuffer buffer = writer.DetachBuffer();
            try { rislOutService.NotifyValueAsync(buffer); } catch { }  // Just try and pump without waiting...
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        private void NotifySpecificScanner(string msg, BluetoothDeviceId deviceID)
        {
            // Usual route
            var writer = new DataWriter();
            writer.ByteOrder = ByteOrder.LittleEndian;
            writer.WriteString(msg);
            IBuffer buffer = writer.DetachBuffer();

            lock (activeBLEClients)
            {
                foreach (GattSubscribedClient client in activeBLEClients)
                {
                    if (client.Session.DeviceId.Id == deviceID.Id)
                    {
                        try { rislOutService.NotifyValueAsync(buffer, client); } catch { } // Just try and pump without waiting...
                        return;
                    }
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public string GetAirscanBarcode()
        {
            // QR Code Payload To Connect to this Server
            //string barcode = "BLE {\"action\":\"config\",\"command\":{\"bleService\":\"<uuid>\"}}";
            string barcode = "{\"action\":\"config\",\"command\":{\"verbs\":[],\"mode\":\"ble\",\"bleService\":\"<uuid>\"}}";
            barcode =barcode.Replace("<uuid>", serverUUID.ToString());
            return barcode;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        // Ok what you want to do with a barcode?  I.E. TRP Lookup etc.
        // 1) BarcodeIn => Calls SomeBusinessLogic With the Barcode => Calls Notify
        // 2) Process the Barcode Here
        // 3) BarcodeIn then sends this RISLCard Out
        private string SomeBusinessLogic(string barcode)
        {
            //string hexColor=#004F94
            //string risl = "{\"action\": \"risl\",\"command\": \"^StartCard|290|160^CardBackColor|" + hexColor + "^Font|28|#FFFFFF^TextC|5|" + DateTime.Now.ToString("HH:mm:ss.fff") + "^Font|24|Bold|#FFFFFF^TextC|48|" + barcode + "^Font|28|#FFFFFF^TextC|115|Echo^PlaySound|Good^ShowCard\"}";
            // A cleaner way to chain together card elements

            Random rnd = new Random(); // for random colored cards
            Color randomColor = Color.FromArgb(rnd.Next(128), rnd.Next(128), 255);
            string hexColor = ColorTranslator.ToHtml(randomColor);
            RISLCard risl = new RISLCard(290, 160);
            risl.SetBackColor(hexColor).SetForeColor(Color.White);
            risl.SetFont(28, false).TextCenter(5, DateTime.Now.ToString("HH:mm:ss.fff"));
            risl.SetFont(24, true).TextCenter(48, barcode);
            risl.SetFont(28, false).TextCenter(115, "Echo");
            risl.PlayGoodSound();
            return risl.GetRISLAsJson(); 
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        private string GetConnectedRISLCard(string deviceID)
        {
            /*
            //BluetoothLE#BluetoothLE94:e6:f7:2c:d3:18-71:d8:45:61:f1:66
            RISLCard risl = new RISLCard(290, 160);
            risl.Clear().SetBackColor(Color.Blue).SetForeColor(Color.White);
            risl.SetFont(28, false).TextCenter(5, "USPS DSS");
            risl.SetFont(32, true).TextCenter(48, "Connected!");
            risl.SetFont(28, false).TextCenter(115, GetFriendlyDeviceID(deviceID));
            risl.PlayGoodSound();
            return risl.GetRISLAsJson();
            */

            RISLCard risl = new RISLCard(290, 130);
            risl.Clear(); // Clear card history
            risl.SetBackColor("#006400").SetForeColor(Color.White).SetFont(42, true);
            risl.TextCenter(8, "DSS").TextCenter(58, "Connected");
            risl.Vibrate(1).PlayGoodSound();
            return risl.GetRISLAsJson();
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public static string GetFriendlyDeviceID(string deviceID)
        {
            //BluetoothLE#BluetoothLE94:e6:f7:2c:d3:18-71:d8:45:61:f1:66
            string[] words = deviceID.Split('-');
            if (words.Length >= 2) return words[1]; else return deviceID; // i.e. 71:d8:45:61:f1:66
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
    }
}