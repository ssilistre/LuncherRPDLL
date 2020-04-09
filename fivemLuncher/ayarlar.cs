using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace fivemLuncher
{

    public class ayarlar
    {
        [DllImport("kernel32.dll")]
        static extern uint GetPrivateProfileString(string kategori, string anahtar, string lpDefault, StringBuilder sb, int sbKapasite, string dosyaAdi);
        /* Bütün Tanımlamalar ve Ayarlar*/
        private string kontrolEdilicekUrl = "https://www.fivemtr.net/misc.php?page=guncelle";
       private string hileKontrol = "";
       private string gorsellerLink = "";
       private string jsonVerisi = "";
       private string jsonVerisi_oyuncu = "";
       private string ip_ana = "";
       private string port_ana = "";
       private string ip_cekilen = "";
       private string port_cekilen = "";
       private string ozelno_ana = "";
       public string programSurumu="";
       public string ReklamMetni="";
       private string flag = "0";
       private string baslikHatalar = "";
       private string guncellemeLink = "";
       private string[] definedPrograms = {};
       public string[] gorseller = { };
       private string avatarUrl = "";
       private string userName = "";
       private string sunucuKayitLink="";
       private string sunucuOnlinesayisi = "";
       private string kayitliSteamid = Properties.Settings.Default.steamid; //sss
        /* Bütün Tanımlamalar ve Ayarlar*////

        /*********************************
         *                              *
         *                              *
         *                              *
         *                              *
         *                              */
        public string _luncherBaslik = "Fivem Luncher SSilistre";
        public string _weebHookLink = "";
        public string _discordLink = "https://discord.gg/FX9jRCW";
        public string _oyunip = "";
        public string _oyunport = "";
        public string _ozelsunucuno = "0";
        public string _reklamMetni = "";
        public string _resim1Link = "";
        public string _resim2Link = "";
        public string _resim3Link = "";
        /*********************************
       *                              *
       *                              *
       *                              *
       *                              *
       *                              */
        /*********************************
     *                              *
     *                              *
     *                              *
     *                              *
     *                              */
        public void servisKontrol()
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable() == true)
                {
                    HttpWebRequest request = WebRequest.Create(kontrolEdilicekUrl) as HttpWebRequest;
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        jsonVerisi = reader.ReadToEnd();
                        JObject json = JObject.Parse(jsonVerisi);
                        programSurumu = json["version"].ToString();
                        ReklamMetni = json["reklamMetni"].ToString();
                        hileKontrol = json["kontrolEdilicekler"].ToString();
                        baslikHatalar = json["baslik"].ToString();
                        guncellemeLink = json["guncellemelink"].ToString();
                        ip_ana = json["ip"].ToString();
                        port_ana = json["port"].ToString();
                        ozelno_ana= json["ozelno"].ToString();
                        flag = json["flag"].ToString();
                        userName= json["username"].ToString();
                        avatarUrl= json["avatarurl"].ToString();
                        sunucuOnlinesayisi = json["sunucuOnlinesayisi"].ToString();
                        gorsellerLink = json["anaGorsel"].ToString();
                        sunucuKayitLink= json["sunucuKayitLink"].ToString();
                        definedPrograms = hileKontrol.Split(',');
                        gorseller = gorsellerLink.Split(',');
                    }
                }
                else
                {
                    MessageBox.Show("İnternet bağlnatısı hatası. Bağlantınız yok!", "FivemTR.NET Luncher Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    kapatProgrami();
                }
            }
            catch (Exception)
            {
              MessageBox.Show(" Bilinmeyen bir hata oluştu. Şimdi sizi githuba yönlendiriyorum. \n Sunucuya erişemedim.Belkide çok eski bir sürüm kullanıyorsun. \n Birşeyler eksik !", "Bilinmeyen Hata");
                linkac("https://github.com/ssilistre/LuncherRP");
                kapatProgrami();
                
            }

        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void hileDurdur()
        {
            if (NetworkInterface.GetIsNetworkAvailable() == true) 
            {
                servisKontrol();
                foreach (var process in definedPrograms)
                {
                    System.Diagnostics.Process.GetProcesses()
                              .Where(x => x.ProcessName.ToLower()
                                           .StartsWith(process))
                              .ToList()
                              .ForEach(x => x.Kill());
                              
                }        
            }
            else
            {
                kapatProgrami();
            }

        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void kapatProgrami()
        {

            foreach (var process in Process.GetProcessesByName("FiveM"))
            {
                process.Kill();
            }
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void guncellemekontrolet()
        {
            if (Application.ProductVersion != programSurumu)
            {
                MessageBox.Show("Bu ürünün yeni bir versionu mevcut lütfen FivemTR.Net Güncel Halini indirin.!", baslikHatalar, MessageBoxButtons.OK, MessageBoxIcon.Error);

                System.Diagnostics.Process.Start(guncellemeLink);
            }
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        private void steamCalissiyormu()
        {
            Process[] processlist = Process.GetProcesses();

            bool steamwebhelperprocess = false;
            bool SteamServiceprocess = false;
            foreach (Process theprocess in processlist)
            {
                switch (theprocess.ProcessName)
                {
                    case "steamwebhelper":
                        steamwebhelperprocess = true;
                        break;
                    case "SteamService":
                        SteamServiceprocess = true;
                        break;
                    default:
                        break;
                }
            }
            if (!(steamwebhelperprocess && SteamServiceprocess))
            {
                MessageBox.Show("Steam açık değil veya giriş yapılmamış lütfen giriş yapınız.", baslikHatalar);
                kapatProgrami();
            }
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void sunucuyabaglan(string ip_numarasi ,string port_numarasi)
        {
            guncellemekontrolet();
            steamCalissiyormu();
            Process.Start("fivem://connect/"+ip_numarasi+":"+port_numarasi);
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void luncherozelgiris(string sunucuanahtar)
        {
                sunucuipogen(sunucuanahtar);
                string str = kayitliSteamid;
                NameValueCollection data = new NameValueCollection();
                WebClient webClient = new WebClient();
                byte[] bytes = webClient.UploadValues("http://oyna.tekyazilim.shop/kayit.php?sunucuid=" + sunucuanahtar + "&steamhexid=" + str + "&online=1&durum=1", "POST", data);
                string @string = Encoding.UTF8.GetString(bytes);
                System.Diagnostics.Process.Start("fivem://connect/" + ip_cekilen + ":" + port_cekilen);
        
            
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void leyjonrpgiris()
        {
            
            
            System.Diagnostics.Process.Start("fivem://connect/" + ip_ana + ":" + port_ana);
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void linkac(string link)
        {
            System.Diagnostics.Process.Start(link);
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public string onlinekackisi(string sunucuanahtar)
        {
            try
            {
                string link = "http://oyna.tekyazilim.shop/oku.php?sunucuid=" + sunucuanahtar;  //link değişkenine çekeceğimiz web sayafasının linkini yazıyoruz.

                Uri url = new Uri(link); //Uri tipinde değişeken linkimizi veriyoruz.

                WebClient client = new WebClient(); // webclient nesnesini kullanıyoruz bağlanmak için.
                client.Encoding = Encoding.UTF8; //türkçe karakter sorunu yapmaması için encoding utf8 yapıyoruz.

                string html = client.DownloadString(url); // siteye bağlanıp tüm sayfanın html içeriğini çekiyoruz.
 
                String kisisayisi = html.ToString();
                return kisisayisi;
            }
            catch (Exception)
            {

                String kisisayisi = "0";
                return kisisayisi;
            }
        }
        /***********************************
         * 
         * 
         * 
         * 
         * 
         * ********************************/
        private static byte[] Post(string uri, NameValueCollection pairs)
        {
            using (WebClient webClient = new WebClient())
                return webClient.UploadValues(uri, pairs);
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void discordMesajYaz(string URL, string msg)
        {
            try
            {
                _ = Post(URL, new NameValueCollection()
        {
                { "username",
                   userName
                },
                {  "avatar_url",
                    avatarUrl

                },
                {
                    "content",
                    msg
                },
            });

            }
            catch (Exception)
            {
                MessageBox.Show("Çok fazla istek gönderildi. Üst üste bu kadar mesaj gönderemezsiniz.");
            }
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void steamidgir()
        {
            Katkilarim myForm = new Katkilarim();
            myForm.ShowDialog();
        }
        /***********************************
       * 
       * 
       * 
       * 
       * 
       * ********************************/
        public string VeriOku(string kategori, string anahtar)
        {
            string veri="";
            try
            {
                String dosyaAdi = Path.GetDirectoryName(Application.ExecutablePath) + "\\luncher_ayar.ini";
                //Okunacak veriyi okumak ve kapasitesini sınırlandırmak ve performans için StringBuilder sınıfını kullanıyoruz.
                StringBuilder sb = new StringBuilder(500);

                GetPrivateProfileString(kategori, anahtar, "", sb, sb.Capacity, dosyaAdi);

                veri = sb.ToString();
                sb.Clear();
                return veri;
            }
            catch (Exception e)
            {
                MessageBox.Show("Ayar ini dosyasını çözümleyemedim. Tekrar Kontrol ediniz.",baslikHatalar);
                return veri;
               
            }
         }
        /***********************************
     * 
     * 
     * 
     * 
     * 
     * ********************************/
        private string sunucuipogen(string sunucuanahtari)
        {
            try
            {
                string bayrak;
                string link = "http://oyna.tekyazilim.shop/sunucubilgisi.php?sunucuid=" + sunucuanahtari;  //link değişkenine çekeceğimiz web sayafasının linkini yazıyoruz.
                Uri url = new Uri(link); //Uri tipinde değişeken linkimizi veriyoruz.
                WebClient client = new WebClient(); // webclient nesnesini kullanıyoruz bağlanmak için.
                client.Encoding = Encoding.UTF8; //türkçe karakter sorunu yapmaması için encoding utf8 yapıyoruz.
                string html = client.DownloadString(url); // siteye bağlanıp tüm sayfanın html içeriğini çekiyoruz.
                String ipadres = html.ToString();
                string[] bilgiler = ipadres.Split(':'); //hobileri , ile ayırıp hobiListe içine aktarıyoruz.
                   
                    ip_cekilen = bilgiler[0];
                    port_cekilen = bilgiler[1];
              
                
                return bayrak = "1";
            }
            catch (Exception)
            {
                string bayrak = "0";
                return bayrak;
            }
        }
      
    }

}
