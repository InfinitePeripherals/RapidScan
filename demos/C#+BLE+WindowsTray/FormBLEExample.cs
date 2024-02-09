using Plugin.BluetoothLE;
using Plugin.BluetoothLE.Server;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reactive.Linq;
using System.Text;
using System.Windows.Forms;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace BLETest
{
    public interface IBleServer
    {
        void Initialise();
    }

    public partial class frmBLEExample : Form, BLEObserver
    {
        BLEServer server;

        public frmBLEExample()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.FormClosing += frmBLEExample_FormClosing;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        // Context menu "Open" item click event handler
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        // Context menu "Exit" item click event handler
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private void frmBLEExample_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if the close reason is user closing the form
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; // Cancel the closing event
                this.Hide(); // Optionally hide the form
                this.WindowState = FormWindowState.Minimized; // Minimize the window
                notifyIcon1.Visible = true; // Ensure the notify icon is visible
            }
        }
        private async void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                lstScanners.Items.Clear();
                server = new BLEServer(this); // Setup BLE Server with this Form being the listner / to update the UI
                await server.Start();
                GenerateOnscreenBarcode(server.GetAirscanBarcode());
            }
            catch 
            {
               MessageBox.Show("Unable to start BLE Server!");
               System.Windows.Forms.Application.Exit();
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public void GenerateOnscreenBarcode(string payload)
        {
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
        //-------------------------------------------------------------------------------------------------------------------------
        public void ScannerListChanged(IReadOnlyList<GattSubscribedClient> activeBLEClients)
        {
            // Loop through the list and make sure all are in the UI
            Action update = delegate {

                // Show the disconnected.  Scanner could be in UI,but not in the scanner liet
                foreach (ListViewItem item in lstScanners.Items)
                {
                    bool foundInList = FoundInActiveScannerList(item.Text, activeBLEClients);
                    if (!foundInList) item.SubItems[3].Text = "Disconnnected";
                }

                // Add the New
                foreach (GattSubscribedClient client in activeBLEClients)
                {
                    string deviceID = BLEServer.GetFriendlyDeviceID(client.Session.DeviceId.Id);
                    ListViewItem item = lstScanners.FindItemWithText(deviceID);
                    if (item == null)
                    {
                        item = new ListViewItem();
                        //item.Text = BLEServer.GetFriendlyDeviceID(client.Session.DeviceId.Id);
                        item.ImageIndex = 0;
                        item.SubItems.Add("BLE");
                        item.SubItems.Add(deviceID);
                        item.SubItems.Add("Connected");
                        item.SubItems.Add("0"); // Scan Count
                        item.SubItems.Add(""); // Last Barcode
                        lstScanners.Items.Add(item);
                    }
                    else item.SubItems[3].Text = "Connnected"; // For the disconnected that came back around / all these are connected now
                }


                lblScannerCount.Text = activeBLEClients.Count.ToString() + " Scanners Connected";
            };
            lstScanners.Invoke(update);
        }
        //-------------------------------------------------------------------------------------------------------------------------
        // See if the scanner in the list is still active or not in the connected list
        bool FoundInActiveScannerList(string deviceID, IReadOnlyList<GattSubscribedClient> activeBLEClients )
        {
          foreach ( var client in activeBLEClients )
          {
                if (BLEServer.GetFriendlyDeviceID(client.Session.DeviceId.Id) == deviceID) return true;
          }
           return false;
        }
        //-------------------------------------------------------------------------------------------------------------------------
        public void ScanIn(string deviceID, string barcode)
        {
            Action update = delegate
            {
                ListViewItem item = lstScanners.FindItemWithText(BLEServer.GetFriendlyDeviceID(deviceID));
                if (item == null) return;

                item.SubItems[4].Text = "" + (int.Parse(item.SubItems[4].Text) + 1);
                item.SubItems[5].Text = barcode;
            };
            lstScanners.Invoke(update);
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Show the form when "Open" is clicked
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }
        //-------------------------------------------------------------------------------------------------------------------------
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Exit the application
        }
        //-------------------------------------------------------------------------------------------------------------------------
    }
}