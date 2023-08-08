namespace BLETest
{
    partial class frmBLEExample
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "BLE",
            "xx:xx:xx:xx",
            "Connected",
            "0",
            "Last Barcode"}, 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBLEExample));
            this.picConfig = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblScannerCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstScanners = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picConfig)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picConfig
            // 
            this.picConfig.BackColor = System.Drawing.Color.DimGray;
            this.picConfig.Location = new System.Drawing.Point(660, 30);
            this.picConfig.Name = "picConfig";
            this.picConfig.Size = new System.Drawing.Size(128, 128);
            this.picConfig.TabIndex = 0;
            this.picConfig.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumBlue;
            this.panel1.Controls.Add(this.lblScannerCount);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 405);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 45);
            this.panel1.TabIndex = 1;
            // 
            // lblScannerCount
            // 
            this.lblScannerCount.AutoSize = true;
            this.lblScannerCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblScannerCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScannerCount.ForeColor = System.Drawing.Color.White;
            this.lblScannerCount.Location = new System.Drawing.Point(0, 0);
            this.lblScannerCount.Margin = new System.Windows.Forms.Padding(10);
            this.lblScannerCount.Name = "lblScannerCount";
            this.lblScannerCount.Size = new System.Drawing.Size(342, 37);
            this.lblScannerCount.TabIndex = 0;
            this.lblScannerCount.Text = "0 Scanners Connected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(667, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Airscan BLE QR Code";
            // 
            // lstScanners
            // 
            this.lstScanners.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.lstScanners.FullRowSelect = true;
            this.lstScanners.GridLines = true;
            this.lstScanners.HideSelection = false;
            this.lstScanners.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lstScanners.Location = new System.Drawing.Point(0, 2);
            this.lstScanners.Name = "lstScanners";
            this.lstScanners.Size = new System.Drawing.Size(654, 397);
            this.lstScanners.SmallImageList = this.imgIcons;
            this.lstScanners.TabIndex = 3;
            this.lstScanners.UseCompatibleStateImageBehavior = false;
            this.lstScanners.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Model";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Connection Type";
            this.columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Address";
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "State";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "#Scans";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Last Barcode";
            this.columnHeader6.Width = 300;
            // 
            // imgIcons
            // 
            this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
            this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcons.Images.SetKeyName(0, "HaloRingScanner64x62.png");
            // 
            // frmBLEExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstScanners);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.picConfig);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmBLEExample";
            this.Text = "BLE Connect  Example";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.picConfig)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picConfig;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstScanners;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ImageList imgIcons;
        private System.Windows.Forms.Label lblScannerCount;
    }
}

