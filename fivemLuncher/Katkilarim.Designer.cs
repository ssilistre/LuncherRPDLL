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
            this.lblSteamid = new System.Windows.Forms.Label();
            this.txtSteamid = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbltr
            // 
            this.lbltr.AutoSize = true;
            this.lbltr.BackColor = System.Drawing.Color.Transparent;
            this.lbltr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbltr.Location = new System.Drawing.Point(62, 4);
            this.lbltr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltr.Name = "lbltr";
            this.lbltr.Size = new System.Drawing.Size(333, 17);
            this.lbltr.TabIndex = 0;
            this.lbltr.Text = "Bu sistemi kullandığınız için teşekkür ederim.";
            // 
            // lbleng
            // 
            this.lbleng.AutoSize = true;
            this.lbleng.BackColor = System.Drawing.Color.Transparent;
            this.lbleng.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbleng.Location = new System.Drawing.Point(100, 27);
            this.lbleng.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbleng.Name = "lbleng";
            this.lbleng.Size = new System.Drawing.Size(244, 17);
            this.lbleng.TabIndex = 1;
            this.lbleng.Text = "Thank you for using this system.";
            // 
            // lblSteamid
            // 
            this.lblSteamid.AutoSize = true;
            this.lblSteamid.BackColor = System.Drawing.Color.Transparent;
            this.lblSteamid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSteamid.Location = new System.Drawing.Point(169, 50);
            this.lblSteamid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSteamid.Name = "lblSteamid";
            this.lblSteamid.Size = new System.Drawing.Size(71, 17);
            this.lblSteamid.TabIndex = 5;
            this.lblSteamid.Text = "Steamid:";
            // 
            // txtSteamid
            // 
            this.txtSteamid.Location = new System.Drawing.Point(92, 71);
            this.txtSteamid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSteamid.Name = "txtSteamid";
            this.txtSteamid.Size = new System.Drawing.Size(230, 20);
            this.txtSteamid.TabIndex = 6;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(124, 97);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(164, 26);
            this.btnKaydet.TabIndex = 7;
            this.btnKaydet.Text = "Kaydet/Save";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Location = new System.Drawing.Point(11, 102);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(92, 13);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Steamid ni öğren !";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Location = new System.Drawing.Point(313, 102);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(89, 13);
            this.linkLabel2.TabIndex = 9;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "find your steam id";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // Katkilarim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(413, 130);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtSteamid);
            this.Controls.Add(this.lblSteamid);
            this.Controls.Add(this.lbleng);
            this.Controls.Add(this.lbltr);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Katkilarim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thank you for all / Teşekkürler";
            this.Load += new System.EventHandler(this.Katkilarim_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbltr;
        private System.Windows.Forms.Label lbleng;
        private System.Windows.Forms.Label lblSteamid;
        private System.Windows.Forms.TextBox txtSteamid;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}