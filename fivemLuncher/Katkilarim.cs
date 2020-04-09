using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace fivemLuncher
{
    public partial class Katkilarim : Form
    {

        ayarlar ayarlar = new ayarlar();
        public Katkilarim()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        //    ayarlar.linkac("https://steamid.co/");  
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("1-Açılan sitede 'enter your input' yazısını bulun.\n2-Ardından steam profil sayfanızın linkini yapıştırın ve enter tuşuna basın.\n3-Açılan sayfadaki Steam 64 ID kopyalayın.\n4- Programdaki boş alana yapıştırın kaydet diyin.", "Steam ID Nasıl Bulunur ?");
             ayarlar.linkac("https://steamid.co/");
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                long sayi = Convert.ToInt64(txtSteamid.Text);
                String b = Convert.ToString(sayi, 16);
                string c = "steam:" + b;
                Properties.Settings.Default.steamid = c;
                Properties.Settings.Default.Save();
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen sadece steamid 64 numarasini giriniz.\n Please just put steamid 64 number.","Steam id hatası/error");
            }
        }

        private void slider_timer_Tick(object sender, EventArgs e)
        {
           
        }

        private void Katkilarim_Load(object sender, EventArgs e)
        {
            txtSteamid.Text = Properties.Settings.Default.steamid;
           
        }
    }
}
