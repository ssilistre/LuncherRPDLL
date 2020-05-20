using DiscordRPC;
using Microsoft.Win32;
using System;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace fivemLuncher
{

    public class lib
    {
      
        [DllImport("psapi.dll")]
        private static extern bool EmptyWorkingSet(IntPtr hProcess);
        Settings s = new Settings();

        public DiscordRpcClient Client { get; private set; }

        void Setup()
        {
            Client = new DiscordRpcClient(jsonClass.discordrc);  //Creates the client
            Client.Initialize();                            //Connects the client
        }
        void Update()
        {
            //Invoke the events once per-frame. The events will be executed on calling thread.
            Client.Invoke();
        }
        /* Bütün Tanımlamalar ve Ayarlar*/


        public string sunucuDurum = "";
        public string  duyurular = "";
        private string baslikHatalar="FivemCode System";
        public int KisiSayisi = 0;
        long steamnewid =0;
        private string kayitliSteamid = Properties.Settings.Default.steamid;
        private string _serverkey ="";
        public string postalanicak = "";
        /* Bütün Tanımlamalar ve Ayarlar*////
        /*********************************/
        /*********************************/
        /*********************************/
        /*********************************/

        public lib()
        {
             
        }

        /*********************************/
        /*******Public Olanlar*********/
        /*********************************
        /*********************************/
         
        public void serverinfos(String serverkey)
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable() == true)
                {
                
                    var sonuc = connectionOutSide.getPost(s.luncherinfo_url, serverkey);

                    if (sonuc==false)
                    {
                        var sonuc2 = connectionOutSide.getPost(s.apiv2info_url, serverkey);
                        if (sonuc2==false)
                        {
                            var sonuc3 = connectionOutSide.getPost(s.apiv3info_url, serverkey);
                        }
                    }
                    _serverkey = serverkey;
                     duyurular = jsonClass.duyurular;
                    sunucuDurum = jsonClass.sunucu;
                    KisiSayisi = jsonClass.onlinekisi;
                    steamnewid=Steam32ToSteam64(SteamLogin());
                    update();
                }
                else
                {
                    MessageBox.Show("İnternet bağlnatısı hatası. Bağlantınız yok! \n Your internet connection fail !", baslikHatalar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    closeFivem();
                }
            }
            catch (Exception e)
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
            string[] definedPrograms = jsonClass.kontrolEdilicekler.Split(',');
            try
            {
                foreach (var item in definedPrograms)
                {
                    var process = Process.GetProcesses().Where(x =>
                    x.ProcessName.ToLower().StartsWith(item) ||
                    x.ProcessName.ToLower().Contains(item) ||
                    x.ProcessName.ToLower() == item ||
                    x.MainWindowTitle.ToLower() == item);
                    if (process.Any())
                    {
                        var isim = "";
                        process.ToList().ForEach(x => isim = x.MainWindowTitle.ToString());
                        process.ToList().ForEach(x => x.Kill());
                        postalanicak = isim.Trim().ToLower().Replace(" ", "_");
                        HackSend();
                        closeFivem();
                    }
                }

            }
            catch (Exception)
            {
                foreach (var item in definedPrograms)
                {
                    var process = Process.GetProcesses().Where(x =>
                    x.ProcessName.ToLower().StartsWith(item) ||
                    x.ProcessName.ToLower().Contains(item) ||
                    x.ProcessName.ToLower() == item ||
                    x.MainWindowTitle.ToLower() == item);
                    if (process.Any())
                    {
                       
                        process.ToList().ForEach(x => x.Kill());
                       
                    }
                }

            }


/*
            if (NetworkInterface.GetIsNetworkAvailable() == true) 
            {
               
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
            */
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
                   jsonClass.discordbot
                },
                {  "avatar_url",
                    jsonClass.avatarurl

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
        public void DicordRC(string serverName,string secMsg,string thirdMsg)
        {


            try
            {
                Setup();
                Update();
                Client.SetPresence(new RichPresence()
                {
                    Details = serverName.ToString(),
                    State = secMsg.ToString(),
                    Assets = new Assets()
                    {
                        LargeImageKey = jsonClass.discordRCbuyukResim,
                        LargeImageText = thirdMsg.ToString(),
                        SmallImageKey = jsonClass.discordRCkucukResim
                    }
                });
            }
            catch (Exception)
            {

               
            }
          
        }
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

                MessageBox.Show("Lütfen Sadece Steam64ID nizi giriniz. \n Pls make sure write steam64 id !","Steam ID Hatası");
            }
        }     
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
        public void update()
        {
            try
            {
                ini.VeriYaz("Ayarlar", "Version", Application.ProductVersion);
                if (Application.ProductVersion == jsonClass.version)
                {
                  
                }
                else
                {
                    ini.VeriYaz("Ayarlar", "Ad", System.AppDomain.CurrentDomain.FriendlyName);
                    ini.VeriYaz("Ayarlar", "Version", Application.ProductVersion);
                    ini.VeriYaz("Ayarlar", "YeniVersion", jsonClass.version);
                    ini.VeriYaz("Ayarlar", "indirilicekAdres", jsonClass.guncellemelink);
                    string dizinYolu = Path.GetDirectoryName(Application.ExecutablePath);
                    string dosyaAdi = dizinYolu + "\\FiveMCodeUpdater.exe";
                    Process.Start(dosyaAdi);
                    System.Environment.Exit(1);
                }
            }
            catch (Exception)
            {

                
            }
        }
        public void connectWithPanel(String serverkey)
        {
            try 
            {
                steamCalissiyormu();
                kayitliSteamid = SteamLogin();
                steamnewid = Steam32ToSteam64(SteamLogin());
                long sayi = Convert.ToInt64(steamnewid);
                String b = Convert.ToString(sayi, 16);
                string value = "steam:" + b;

                if (jsonClass.ip == "")
                {
                    serverinfos(serverkey);
                }


                if (jsonClass.whitelist=="yok")
                {
                    String Durum = "1";
                    var sonucKayit = connectionOutSide.getRegister(s.luncherReg_url, serverkey, value, steamnewid.ToString(),Durum);

                    if (sonucKayit == "")
                    {
                        var sonucKayit2 = connectionOutSide.getRegister(s.apiv2reg_url, serverkey, value, steamnewid.ToString(), Durum);

                        if (sonucKayit2== "")
                        {
                            var sonucKayit3 = connectionOutSide.getRegister(s.apiv3reg_url, serverkey, value, steamnewid.ToString(), Durum);
                        }
                    }
                    


                    System.Diagnostics.Process.Start("fivem://connect/" + jsonClass.ip + ":" + jsonClass.port);
                }
                else
                {
                    String Durum = "3";
                    var sonuc = connectionOutSide.getRegister(s.luncherReg_url, serverkey, value, steamnewid.ToString(), Durum);

                    if (sonuc == "")
                    {
                        var sonuc2 = connectionOutSide.getRegister(s.apiv2reg_url, serverkey, value, steamnewid.ToString(), Durum);

                        if (sonuc2 == "")
                        {
                            var sonuc3 = connectionOutSide.getRegister(s.apiv3reg_url, serverkey, value, steamnewid.ToString(), Durum);
                        }
                    }
                    System.Diagnostics.Process.Start("fivem://connect/" + jsonClass.ip + ":" + jsonClass.port);
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Panel ile iletişim kurulurken bir sorunla karşılaştık.","FivemCode System",MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
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
        private void HackSend()
        {
            try
            {
                var sonuc = connectionOutSide.getPostHack(s.apihack_url, _serverkey, steamnewid.ToString(), postalanicak);
                if (sonuc == false)
                {
                    var sonuc2 = connectionOutSide.getPostHack(s.api2hack_url, _serverkey, steamnewid.ToString(), postalanicak);

                    if (sonuc2 == false)
                    {
                        var sonuc3 = connectionOutSide.getPostHack(s.api2hack_url, _serverkey, steamnewid.ToString(), postalanicak);
                    }
                }
            }
            catch (Exception)
            {

                 
            }
        }
    }
}
 
 
