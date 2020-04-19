using fivemLuncher;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace LeyjonRPLuncher
{
    public partial class Luncher : Form
    {
        lib rp = new lib();
       
        public Luncher()
        {
            //****************************************
            InitializeComponent();
            
            //****************************************
        }
        private void Luncher_Load(object sender, EventArgs e)
        {
         
            rp.DicordRC("Sunucu adi buraya yaziniz.", ""); //Discord durumunu değiştirmenize yarar ikinci "" tırnağı boş bırakırsı
           

        }
        private void Luncher_FormClosing(object sender, FormClosingEventArgs e)
        {
            rp.closeFivem(); // When closing form - close to fivem.
        }
       
       
        private void hileKontrol_Tick(object sender, EventArgs e)
        {
            rp.stopHacks(); //Hack & tools blocked. If find any working hack pls create issue on github.
            //StopHacks kodu hileleri kontrol eden kod bloğu.
        }

        private void btnOyna_Click(object sender, EventArgs e)
        {
            // rp.oldConnectionPanel("serverkey"); //Sunucuya luancher olmadan giriş için. //Register panel.fivemcode.com after that put inside server key.
            // rp.connectFivem("ip", "port"); // Sunucuya normal bağlanmak için. //Connect normal server.
           
        }
        
    }
}
    