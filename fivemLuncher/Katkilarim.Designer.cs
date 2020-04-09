namespace fivemLuncher
{
    partial class Katkilarim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Katkilarim));
            this.lbltr = new System.Windows.Forms.Label();
            this.lbleng = new System.Windows.Forms.Label();
            this.resimKutusu = new System.Windows.Forms.PictureBox();
            this.lblSteamid = new System.Windows.Forms.Label();
            this.txtSteamid = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.resimKutusu)).BeginInit();
            this.SuspendLayout();
            // 
            // lbltr
            // 
            this.lbltr.AutoSize = true;
            this.lbltr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbltr.Location = new System.Drawing.Point(83, 5);
            this.lbltr.Name = "lbltr";
            this.lbltr.Size = new System.Drawing.Size(390, 20);
            this.lbltr.TabIndex = 0;
            this.lbltr.Text = "Bu sistemi kullandığınız için teşekkür ederim.";
            // 
            // lbleng
            // 
            this.lbleng.AutoSize = true;
            this.lbleng.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbleng.Location = new System.Drawing.Point(134, 33);
            this.lbleng.Name = "lbleng";
            this.lbleng.Size = new System.Drawing.Size(282, 20);
            this.lbleng.TabIndex = 1;
            this.lbleng.Text = "Thank you for using this system.";
            // 
            // resimKutusu
            // 
            this.resimKutusu.ImageLocation = "https://i.hizliresim.com/yjgeOL.png";
            this.resimKutusu.Location = new System.Drawing.Point(-1, 144);
            this.resimKutusu.Name = "resimKutusu";
            this.resimKutusu.Size = new System.Drawing.Size(552, 145);
            this.resimKutusu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.resimKutusu.TabIndex = 4;
            this.resimKutusu.TabStop = false;
            this.resimKutusu.WaitOnLoad = true;
            // 
            // lblSteamid
            // 
            this.lblSteamid.AutoSize = true;
            this.lblSteamid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSteamid.Location = new System.Drawing.Point(225, 61);
            this.lblSteamid.Name = "lblSteamid";
            this.lblSteamid.Size = new System.Drawing.Size(83, 20);
            this.lblSteamid.TabIndex = 5;
            this.lblSteamid.Text = "Steamid:";
            // 
            // txtSteamid
            // 
            this.txtSteamid.Location = new System.Drawing.Point(123, 82);
            this.txtSteamid.Name = "txtSteamid";
            this.txtSteamid.Size = new System.Drawing.Size(306, 22);
            this.txtSteamid.TabIndex = 6;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(206, 109);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(121, 32);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(12, 117);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(122, 17);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Steamid ni öğren !";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(404, 117);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(120, 17);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "find your steam id";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Katkilarim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 263);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtSteamid);
            this.Controls.Add(this.lblSteamid);
            this.Controls.Add(this.resimKutusu);
            this.Controls.Add(this.lbleng);
            this.Controls.Add(this.lbltr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Katkilarim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thank you for all / Teşekkürler";
            this.Load += new System.EventHandler(this.Katkilarim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resimKutusu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltr;
        private System.Windows.Forms.Label lbleng;
        private System.Windows.Forms.PictureBox resimKutusu;
        private System.Windows.Forms.Label lblSteamid;
        private System.Windows.Forms.TextBox txtSteamid;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}