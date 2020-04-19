namespace LeyjonRPLuncher
{
    partial class Luncher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Luncher));
            this.hileKontrol = new System.Windows.Forms.Timer(this.components);
            this.btnOyna = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hileKontrol
            // 
            this.hileKontrol.Interval = 1000;
            this.hileKontrol.Tick += new System.EventHandler(this.hileKontrol_Tick);
            // 
            // btnOyna
            // 
            this.btnOyna.Location = new System.Drawing.Point(534, 282);
            this.btnOyna.Name = "btnOyna";
            this.btnOyna.Size = new System.Drawing.Size(188, 62);
            this.btnOyna.TabIndex = 0;
            this.btnOyna.Text = "Oyna";
            this.btnOyna.UseVisualStyleBackColor = true;
            this.btnOyna.Click += new System.EventHandler(this.btnOyna_Click);
            // 
            // Luncher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 356);
            this.Controls.Add(this.btnOyna);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Luncher";
            this.Text = "---------Fivem Luncher | SSilistre";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Luncher_FormClosing);
            this.Load += new System.EventHandler(this.Luncher_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer hileKontrol;
        private string ip_ana;
        private string port_ana;
        private object definedPrograms;
        private object gorseller;
        private System.Windows.Forms.Button btnOyna;
    }
}