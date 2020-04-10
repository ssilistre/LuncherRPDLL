using Microsoft.Win32;
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
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        [DllImport("kernel32.dll")]
        static extern uint GetPrivateProfileString(string kategori, string anahtar, string lpDefault, StringBuilder sb, int sbKapasite, string dosyaAdi);
        [DllImport("psapi.dll")]
        public static extern bool EmptyWorkingSet(IntPtr hProcess);
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
       private string kisiSayisi = "";
       private string kayitliSteamid = Properties.Settings.Default.steamid; //sss
       /* Bütün Tanımlamalar ve Ayarlar*////
        /*********************************/
        /*********************************/
        /*********************************/
        /*********************************/

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
                MessageBox.Show("Luancher Kütüphanesi güncel değil lütfen güncelleyin",baslikHatalar);
                linkac("https://github.com/ssilistre/LuncherRP");
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
            string str = kayitliSteamid;
            if (str=="")
            {
                MessageBox.Show("Lütfen önce steam64id nizi giriniz !");
            }
            else
            {
                sunucuipogen(sunucuanahtar.Trim());
                NameValueCollection data = new NameValueCollection();
                WebClient webClient = new WebClient();
                byte[] bytes = webClient.UploadValues("http://oyna.tekyazilim.shop/kayit.php?sunucuid=" + sunucuanahtar + "&steamhexid=" + str + "&online=1&durum=1", "POST", data);
                string @string = Encoding.UTF8.GetString(bytes);
                System.Diagnostics.Process.Start("fivem://connect/" + ip_cekilen + ":" + port_cekilen);
            }
                 
        
            
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
                string link = "http://oyna.tekyazilim.shop/oku.php?sunucuid=" + sunucuanahtar.Trim();
                Uri url = new Uri(link); 
                WebClient client = new WebClient(); 
                client.Encoding = Encoding.UTF8; 
                string html = client.DownloadString(url);
                String kisisayisi = html.ToString();
                kisiSayisi = kisisayisi;
                return kisiSayisi;
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
        public void steamidgirformu()
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
        public void DicordRC(string Sunucuadı,String altmesaj)
        {
            try
            {
                this.handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize("698182166168993862", ref this.handlers, true, null);
                this.handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize("698182166168993862", ref this.handlers, true, null);
                this.presence.details = Sunucuadı;
                this.presence.smallImageText = "Daha detayli bilgilendirme icin github.com/ssilistre ziyaret ediniz. \n Kendi Luancherinizi yapabilirsiniz. Bedavaya";
                if (altmesaj=="")
                {
                    this.presence.state = kisiSayisi + " oyuncu suan online !";
                }
                else
                {
                    this.presence.state = altmesaj;
                }
                this.presence.largeImageKey = "fivem-logo";
                this.presence.smallImageKey = "_mam";
                this.presence.largeImageText = ReklamMetni;
                DiscordRpc.UpdatePresence(ref this.presence);
            }
            catch (Exception)
            {

                
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
        /***********************************
         * 
         * 
         * 
         * 
         * 
         * ********************************/
        public void steamidgir(string hexid)
        {
            try
            {
                long sayi = Convert.ToInt64(hexid.Trim());
                String b = Convert.ToString(sayi, 16);
                string c = "steam:" + b;
                Properties.Settings.Default.steamid = c;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Sadece Steam64ID nizi giriniz.","Steam ID Hatası");
            }
        }
        /***********************************
          * 
          * 
          * 
          * 
          * 
          * ********************************/
        public void optimizeYap()
        {
            try
            {
                Process[] processes = Process.GetProcesses();
                long num = 0L;
                Process[] array = processes;
                foreach (Process process in array)
                {
                    num += process.WorkingSet64;
                }
                num = 0L;
                Process[] array2 = processes;
                foreach (Process process2 in array2)
                {
                    try
                    {
                        EmptyWorkingSet(process2.Handle);
                    }
                    catch
                    {
                    }
                }
                processes = Process.GetProcesses();
                Process[] array3 = processes;
                foreach (Process process3 in array3)
                {
                    num += process3.WorkingSet64;
                }
            }
            catch (Exception)
            {

             
            }
            }
        /***********************************
         * 
         * 
         * 
         * 
         * 
         * ********************************/
        
    }
}

