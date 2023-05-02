namespace Airscan
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lvClients = new System.Windows.Forms.ListView();
            this.lblConnected = new System.Windows.Forms.Label();
            this.picConfig = new System.Windows.Forms.PictureBox();
            this.lblConfigure = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.picLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // lvClients
            // 
            this.lvClients.GridLines = true;
            this.lvClients.HideSelection = false;
            this.lvClients.LabelEdit = true;
            this.lvClients.Location = new System.Drawing.Point(12, 35);
            this.lvClients.MultiSelect = false;
            this.lvClients.Name = "lvClients";
            this.lvClients.ShowGroups = false;
            this.lvClients.Size = new System.Drawing.Size(1108, 191);
            this.lvClients.TabIndex = 0;
            this.lvClients.UseCompatibleStateImageBehavior = false;
            this.lvClients.View = System.Windows.Forms.View.Details;
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.Location = new System.Drawing.Point(13, 16);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(101, 13);
            this.lblConnected.TabIndex = 1;
            this.lblConnected.Text = "Connected Devices";
            // 
            // picConfig
            // 
            this.picConfig.BackColor = System.Drawing.Color.White;
            this.picConfig.Location = new System.Drawing.Point(12, 252);
            this.picConfig.Name = "picConfig";
            this.picConfig.Size = new System.Drawing.Size(165, 165);
            this.picConfig.TabIndex = 2;
            this.picConfig.TabStop = false;
            // 
            // lblConfigure
            // 
            this.lblConfigure.AutoSize = true;
            this.lblConfigure.Location = new System.Drawing.Point(13, 236);
            this.lblConfigure.Name = "lblConfigure";
            this.lblConfigure.Size = new System.Drawing.Size(109, 13);
            this.lblConfigure.TabIndex = 3;
            this.lblConfigure.Text = "AirScan Configuration";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1132, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.White;
            this.picLogo.Image = global::AirscanMQTTDemo.Properties.Resources.AirScanLogoFinalOff;
            this.picLogo.Location = new System.Drawing.Point(933, 252);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(187, 165);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 5;
            this.picLogo.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 451);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblConfigure);
            this.Controls.Add(this.picConfig);
            this.Controls.Add(this.lblConnected);
            this.Controls.Add(this.lvClients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "AirScan MQTT Demo";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvClients;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.PictureBox picConfig;
        private System.Windows.Forms.Label lblConfigure;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.PictureBox picLogo;
    }
}

