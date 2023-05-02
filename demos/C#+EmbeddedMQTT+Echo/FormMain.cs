using System.Windows.Forms;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using QRCoder;
using System.Drawing;
using Airscan.MQTT;

namespace Airscan
{
    public partial class FormMain : Form
    {
        EmbeddedMQTTServer server; // This is just a simple routing service
        TopicRouter messageRouter; // Main Logic!
        //--------------------------------------------------------------------------------------------------------------
        public FormMain()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------------------------------------------------
        private void FormMain_Load(object sender, System.EventArgs e)
        {
            Initialize();

        }
        //--------------------------------------------------------------------------------------------------------------
        public void Initialize()
        {
            // Step1: How do the Airscan Clients connect to this app?
            GenerateOnscreenBarcode(); // The barcode for any RS to connect.  Note: has to be on same network as laptop

            // Step2: What MQTT Server will receive the incoming scans?
            server = new Airscan.MQTT.EmbeddedMQTTServer(Settings.mqttPort, Settings.mqttUid, Settings.mqttPwd);
            UIStats.SetListView(lvClients);
            UIStats.SetLogo(picLogo);

            // Step: How should the incoming scans be handled?
            messageRouter = new TopicRouter(); // Listens for messages and respond
        }
        //--------------------------------------------------------------------------------------------------------------
        public void GenerateOnscreenBarcode()
        {
            // Get the IP etc. to put into the Config
            AirscanConfig config = new AirscanConfig();
            var ip = GetLocalIPv4();  // I like this way better...
            //var ip = GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            config.WithMQTTServer(ip, Settings.mqttUid, Settings.mqttPwd, Settings.mqttPort, Settings.mqttTopic);
            config.AddVerb("Echo", 1);
            var payload = config.ToString();

            // Draw the QR
            QRCodeGenerator.ECCLevel eccLevel = (QRCodeGenerator.ECCLevel)(3);
            using (QRCodeGenerator qrGenerator = new QRCodeGenerator())
            using (QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, eccLevel))
            using (QRCode qrCode = new QRCode(qrCodeData))
            {
                var bmp = qrCode.GetGraphic(2, Color.Black, Color.White, null, (int)0);
                picConfig.BackgroundImage = bmp;
                picConfig.Size = bmp.Size;
            }
        }
        //--------------------------------------------------------------------------------------------------------------
        public string GetLocalIPv4()
        {
            // Bind to UDP Socket and get IP back.  WIll resolve in case there are multiple IPs available.
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
            }
            return localIP;
        }

        //--------------------------------------------------------------------------------------------------------------
        //public string GetLocalIPv4(NetworkInterfaceType _type)
        //{
        //    string output = "";
        //    foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
        //    {
        //        if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
        //        {
        //            foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
        //            {
        //                if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
        //                {
        //                    output = ip.Address.ToString();
        //                }
        //            }
        //        }
        //    }
        //    return output;
        //}
        //--------------------------------------------------------------------------------------------------------------
    } // Form
} // namespace