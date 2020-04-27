using Newtonsoft.Json.Linq;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.IO.Compression;
using System.ComponentModel;
using Ionic.Zip;
using System.Media;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;

namespace fivemLuncher
{

    public class lib
    {
        private DiscordRpc.EventHandlers handlers;
        private DiscordRpc.RichPresence presence;
        [DllImport("psapi.dll")]
        public static extern bool EmptyWorkingSet(IntPtr hProcess);
  
        /* Bütün Tanımlamalar ve Ayarlar*/
        private string kontrolEdilicekUrl = "http://panel.fivemcode.com/guncelleme.php";
        private string hileKontrol = "";
        private string jsonVerisi = "";
        private string ip_ana = "";
        private string port_ana = "";
        private string ip_cekilen = "";
        private string port_cekilen = "";
        private string ReklamMetni="";
        private string flag = "0";
        private string baslikHatalar = "";
        private string guncellemeLink = "";
        private string[] definedPrograms = {};
        private string avatarUrl = "";
        private string userName = "";
        public string kisiSayisi = "";
        private string DosyaYolu = "";
        private string DosyaAdi = "";
        private string DiscordRC = "";
        public string sunucuDurum = "";
        private string version = "";
        public string  duyurular = "";
        public string hileTespit = "";
        long steamnewid =0;
        public string SteamUserName = "";
        private string kayitliSteamid = Properties.Settings.Default.steamid; 
         /* Bütün Tanımlamalar ve Ayarlar*////
        /*********************************/
        /*********************************/
        /*********************************/
        /*********************************/
        public lib()
        {
            //****************************************

            servisKontrol();
            //****************************************
        }
        /***********************************
       * 
       * 
       * 
       * 
       * 
       * ********************************/



        /*********************************/
        /*******Public Olanlar*********/
        /*********************************/
        /*********************************/
        public void serverinfos(String serverkey)
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable() == true)
                {
                    HttpWebRequest request = WebRequest.Create("http://api.fivemcode.com/launcher.php?sunucuid=" + serverkey) as HttpWebRequest;
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml,         image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers["Accept-Language"] = "tr-TR";
                    request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = true;
                    request.Timeout = 60000;
                    request.Method = "GET";
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {

                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        jsonVerisi = reader.ReadToEnd();
                        JObject json = JObject.Parse(jsonVerisi);


                        version = json["version"].ToString();
                        ip_cekilen = json["ip"].ToString();
                        port_cekilen = json["port"].ToString();
                        sunucuDurum = json["sunucu"].ToString();
                        guncellemeLink = json["guncellemelink"].ToString();
                        userName = json["discordbot"].ToString();
                        avatarUrl = json["avatarurl"].ToString();
                        DiscordRC = json["discordrc"].ToString();
                        duyurular = json["duyurular"].ToString();
                        kisiSayisi = json["onlinekisi"].ToString();


                    }


                    steamnewid = Steam32ToSteam64(SteamLogin());

                    HttpWebRequest request2 = WebRequest.Create("http://panel.fivemcode.com/usernamefinder.php?steam64id=" + steamnewid) as HttpWebRequest;
                    request2.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml,         image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request2.Headers["Accept-Language"] = "tr-TR";
                    request2.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                    request2.KeepAlive = true;
                    request2.AllowAutoRedirect = true;
                    request2.Timeout = 60000;
                    request2.Method = "GET";
                    using (HttpWebResponse response2 = request2.GetResponse() as HttpWebResponse)
                    {

                        StreamReader reader2 = new StreamReader(response2.GetResponseStream());
                        SteamUserName = reader2.ReadToEnd();

                    }
                }
                else
                {
                    MessageBox.Show("İnternet bağlnatısı hatası. Bağlantınız yok!", "FivemTR.NET Luncher Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    closeFivem();
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
        public void stopHacks()
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
                closeFivem();
               
            }

        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void closeFivem()
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
        public void connectFivem(string ipNumber ,string portNumber)
        {
          
            steamCalissiyormu();
            Process.Start("fivem://connect/"+ ipNumber + ":"+ portNumber);
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void connectWithOutWhitelist(string serverkey)
        {
            try
            {
                steamCalissiyormu();
                kayitliSteamid = SteamLogin();
                long steamnewid = Steam32ToSteam64(SteamLogin());
                long sayi = Convert.ToInt64(steamnewid);
                String b = Convert.ToString(sayi, 16);
                string value = "steam:" + b;


                if (ip_cekilen == "")
                {
                    serverinfos(serverkey);
                    HttpWebRequest sunucubaglan = WebRequest.Create("http://api.fivemcode.com/kayit.php?sunucuid=" + serverkey + "&steamhexid=" + value + "&steam64id=" + steamnewid + "&online=0&durum=1") as HttpWebRequest;
                    sunucubaglan.Headers["Accept-Language"] = "tr-TR";
                    sunucubaglan.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                    sunucubaglan.KeepAlive = true;
                    sunucubaglan.AllowAutoRedirect = true;
                    sunucubaglan.Timeout = 60000;
                    sunucubaglan.Method = "POST";
                    using (HttpWebResponse sunucuyanit = sunucubaglan.GetResponse() as HttpWebResponse)
                    {

                        StreamReader okuyucu = new StreamReader(sunucuyanit.GetResponseStream());
                        SteamUserName = okuyucu.ReadToEnd();

                    }
                    System.Diagnostics.Process.Start("fivem://connect/" + ip_cekilen + ":" + port_cekilen);
                }
                else
                {
                    HttpWebRequest sunucubaglan = WebRequest.Create("http://api.fivemcode.com/kayit.php?sunucuid=" + serverkey + "&steamhexid=" + value + "&steam64id=" + steamnewid + "&online=1&durum=1") as HttpWebRequest;
                    sunucubaglan.Headers["Accept-Language"] = "tr-TR";
                    sunucubaglan.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                    sunucubaglan.KeepAlive = true;
                    sunucubaglan.AllowAutoRedirect = true;
                    sunucubaglan.Timeout = 60000;
                    sunucubaglan.Method = "POST";
                    using (HttpWebResponse sunucuyanit = sunucubaglan.GetResponse() as HttpWebResponse)
                    {

                        StreamReader okuyucu = new StreamReader(sunucuyanit.GetResponseStream());
                        SteamUserName = okuyucu.ReadToEnd();

                    }
                    System.Diagnostics.Process.Start("fivem://connect/" + ip_cekilen + ":" + port_cekilen);
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
        public void open(string link)
        {
            try
            {
                System.Diagnostics.Process.Start(link);
            }
            catch (Exception)
            {

                MessageBox.Show("Bir sorunla karşılaşıldı Linkac komutundu.");
            }
        }
        /***********************************
        * 
        * 
        * 
        * 
        * 
        * ********************************/
        public void discordMsg(string URL, string msg)
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
        public void steamidform()
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
        public void DicordRC(string serverName,String secMsg)
        {
            try
            {
                this.handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize(DiscordRC, ref this.handlers, true, null);
                this.handlers = default(DiscordRpc.EventHandlers);
                DiscordRpc.Initialize(DiscordRC, ref this.handlers, true, null);
                this.presence.details = serverName;
                this.presence.smallImageText = "Daha detayli bilgilendirme icin github.com/ssilistre ziyaret ediniz. \n Kendi Luancherinizi yapabilirsiniz. Bedavaya";
                if (secMsg == "")
                {
                    this.presence.state = kisiSayisi + " online !";
                }
                else
                {
                    this.presence.state = secMsg;
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
        public void steamid64(string hexid)
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
        public void cacheDelete()
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
        public void zipDownload(String downloadUrl,String _foldername)
        {
            try
            {
                  FolderBrowserDialog W_Dialog = new FolderBrowserDialog();
                W_Dialog.ShowDialog();
                DosyaYolu = W_Dialog.SelectedPath;
                  WebClient webClient = new WebClient();
                webClient.DownloadFile(downloadUrl, _foldername);
                MessageBox.Show("Download complate.\n İndirme başarıyla tamamlandı.","Dosya İndirme");
                using (ZipFile archive = new ZipFile(@"" + System.Environment.CurrentDirectory + "\\"+ _foldername))
                {
                    archive.ExtractAll(@"" + DosyaYolu, ExtractExistingFileAction.OverwriteSilently);
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Bir hata ile karşılaştım. Hatanın olası nedeni indirilen dosya zip olmayabilir.\n Only zip file can be download.",baslikHatalar);
            }
            
           
        }
        /***********************************
       * 
       * 
       * 
       * 
       * 
       * ********************************/
        public void playSound(String soundName)
        {
            try
            {
                SoundPlayer player = new SoundPlayer();
                string path = System.Environment.CurrentDirectory + "\\" + soundName; // Çalmasini istediginiz ses dosyasinin yolu
                player.SoundLocation = path;
                player.Play();
            }
            catch (Exception)
            {

                MessageBox.Show("Müzik Dosyası Bulunamadı.\nFile not found",baslikHatalar);
            }
        }
        /***********************************
      * 
      * 
      * 
      * 
      * 
      * ********************************/
        public void ownUpdate(String versionTxt,String newUpdateDownnloadLink)
        {
                try
                {
                if (versionTxt =="" && newUpdateDownnloadLink =="")
                {
                    if (Application.ProductVersion==version)
                    {
                       

                    }
                    else
                    {
                        string path = Path.GetDirectoryName(Application.ExecutablePath);
                        WebClient wc2 = new WebClient();
                        wc2.DownloadFile(new Uri(guncellemeLink), path + "\\newupdate.exe");
                        System.Diagnostics.Process.Start(path + @"\\newupdate.exe");
                        Application.Exit();
                    }
                }
                else
                {
                    string link = versionTxt;  //link değişkenine çekeceğimiz web sayafasının linkini yazıyoruz.
                    Uri url = new Uri(link); //Uri tipinde değişeken linkimizi veriyoruz.
                    WebClient client = new WebClient(); // webclient nesnesini kullanıyoruz bağlanmak için.
                    client.Encoding = Encoding.UTF8; //türkçe karakter sorunu yapmaması için encoding utf8 yapıyoruz.
                    string html = client.DownloadString(url); // siteye bağlanıp tüm sayfanın html içeriğini çekiyoruz.
                    String version = html.ToString();
                    if (version == Application.ProductVersion)
                    {


                    }
                    else
                    {
                        string path = Path.GetDirectoryName(Application.ExecutablePath);
                        WebClient wc2 = new WebClient();
                        wc2.DownloadFile(new Uri(newUpdateDownnloadLink), path + "\\newupdate.exe");
                        System.Diagnostics.Process.Start(path + @"\\newupdate.exe");
                        Application.Exit();

                    }
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
        public void connectwithWhiteList(String serverkey)
        {
            try
            {
                steamCalissiyormu();
                kayitliSteamid =  SteamLogin();
                steamnewid = Steam32ToSteam64(SteamLogin());
                long sayi = Convert.ToInt64(steamnewid);
                String b = Convert.ToString(sayi, 16);
                string value = "steam:" + b;


                if (ip_cekilen =="")
                {
                    serverinfos(serverkey);
                    HttpWebRequest sunucubaglan = WebRequest.Create("http://api.fivemcode.com/kayit.php?sunucuid=" + serverkey + "&steamhexid=" + value + "&steam64id=" + steamnewid + "&online=0&durum=3") as HttpWebRequest;
                    sunucubaglan.Headers["Accept-Language"] = "tr-TR";
                    sunucubaglan.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                    sunucubaglan.KeepAlive = true;
                    sunucubaglan.AllowAutoRedirect = true;
                    sunucubaglan.Timeout = 60000;
                    sunucubaglan.Method = "POST";
                    using (HttpWebResponse sunucuyanit = sunucubaglan.GetResponse() as HttpWebResponse)
                    {

                        StreamReader okuyucu = new StreamReader(sunucuyanit.GetResponseStream());
                        SteamUserName = okuyucu.ReadToEnd();

                    }
                    System.Diagnostics.Process.Start("fivem://connect/" + ip_cekilen + ":" + port_cekilen);
                }
                else
                {
                    HttpWebRequest sunucubaglan = WebRequest.Create("http://api.fivemcode.com/kayit.php?sunucuid=" + serverkey + "&steamhexid=" + value + "&steam64id=" + steamnewid + "&online=0&durum=3") as HttpWebRequest;
                    sunucubaglan.Headers["Accept-Language"] = "tr-TR";
                    sunucubaglan.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                    sunucubaglan.KeepAlive = true;
                    sunucubaglan.AllowAutoRedirect = true;
                    sunucubaglan.Timeout = 60000;
                    sunucubaglan.Method = "POST";
                    using (HttpWebResponse sunucuyanit = sunucubaglan.GetResponse() as HttpWebResponse)
                    {

                        StreamReader okuyucu = new StreamReader(sunucuyanit.GetResponseStream());
                        SteamUserName = okuyucu.ReadToEnd();

                    }
                    System.Diagnostics.Process.Start("fivem://connect/" + ip_cekilen + ":" + port_cekilen);
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






        /*********************************/
        /**********Tüm Private Olanlar*************/
        /*********************************/
        /*********************************/
        private void servisKontrol()
        {
            try
            {
          
                if (NetworkInterface.GetIsNetworkAvailable() == true)
                {
                    HttpWebRequest request = WebRequest.Create(kontrolEdilicekUrl) as HttpWebRequest;
                    request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml,         image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    request.Headers["Accept-Language"] = "tr-TR";
                    request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
                    request.KeepAlive = true;
                    request.AllowAutoRedirect = true;
                    request.Timeout = 60000;
                    request.Method = "GET";
                    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                    {
                        StreamReader reader = new StreamReader(response.GetResponseStream());
                        jsonVerisi = reader.ReadToEnd();
                        JObject json = JObject.Parse(jsonVerisi);

                        ReklamMetni = json["reklamMetni"].ToString();
                        hileKontrol = json["kontrolEdilicekler"].ToString();
                        baslikHatalar = json["baslik"].ToString();
                        guncellemeLink = json["guncellemelink"].ToString();
                        flag = json["flag"].ToString();
                        userName = json["username"].ToString();
                        avatarUrl = json["avatarurl"].ToString();
                        DiscordRC = json["discordrc"].ToString();
                        definedPrograms = hileKontrol.Split(',');

                    }
                }
                else
                {
                    MessageBox.Show("İnternet bağlnatısı hatası. Bağlantınız yok!", "FivemTR.NET Luncher Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    closeFivem();
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
        private string SteamLogin()
        {
            return "U:1:" + Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Valve").OpenSubKey("Steam").OpenSubKey("ActiveProcess").GetValue("ActiveUser").ToString();
        }
        /***********************************
           * 
           * 
           * 
           * 
           * 
           * ********************************/
        private string DecimalToHexadecimal(long dec)
        {
            try
            {
                if (dec < 1) return "0";

                long hex = dec;
                string hexStr = string.Empty;

                while (dec > 0)
                {
                    hex = dec % 16;

                    if (hex < 10)
                        hexStr = hexStr.Insert(0, Convert.ToChar(hex + 48).ToString());
                    else
                        hexStr = hexStr.Insert(0, Convert.ToChar(hex + 55).ToString());

                    dec /= 16;
                }

                return hexStr.ToLower();
            }
            catch (Exception)
            {
                steamidform();
                return "0";
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
                MessageBox.Show("Please open steam or login steam. \nLütfen steaminizi açın veya giriş yapın.", baslikHatalar);
                closeFivem();
            }
        }
        /***********************************
          * 
          * 
          * 
          * 
          * 
          * ********************************/
        private static long Steam32ToSteam64(string input)
        {
            long steam32 = Convert.ToInt64(input.Substring(4));
            if (steam32 < 1L || !Regex.IsMatch("U:1:" + steam32.ToString((IFormatProvider)CultureInfo.InvariantCulture), "^U:1:([0-9]{1,10})$"))
            {
                return 0;
            }
            return steam32 + 76561197960265728L;
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

 
