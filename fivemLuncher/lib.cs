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
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable EmptyGeneralCatchClause

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
            Client.Invoke();
        }

        /* Bütün Tanımlamalar ve Ayarlar*/
        public string sunucuDurum = "";
        public string duyurular = "";
        public int KisiSayisi = 0;
        long steamnewid = 0;
        private string kayitliSteamid = Properties.Settings.Default.steamid;
        private string _serverkey = "";

        private const string BaslikHatalar = "FivemCode System";

        public lib()
        {

        }

        public void serverinfos(string serverkey)
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {

                var sonuc = connectionOutSide.getPost(s.luncherinfo_url, serverkey);

                if (sonuc == false)
                {
                    var sonuc2 = connectionOutSide.getPost(s.apiv2info_url, serverkey);
                    if (sonuc2 == false)
                    {
                        var sonuc3 = connectionOutSide.getPost(s.apiv3info_url, serverkey);
                    }
                }
                
                _serverkey = serverkey;
                
                duyurular = jsonClass.duyurular;
                
                sunucuDurum = jsonClass.sunucu;
                
                KisiSayisi = jsonClass.onlinekisi;

                steamnewid = Steam32ToSteam64(SteamLogin());

                update();
            }
            else
            {
                MessageBox.Show($@"İnternet bağlnatısı hatası. Bağlantınız yok!{Environment.NewLine}Your internet connection fail!", BaslikHatalar, MessageBoxButtons.OK, MessageBoxIcon.Error);
                closeFivem();
            }
        }

        public void stopHacks()
        {
            var definedPrograms = jsonClass.kontrolEdilicekler.ToLower();
            var processes = Process.GetProcesses();

            Task.Run(() =>
            {
                foreach (var process in processes)
                {
                    var isim = process.MainWindowTitle;
                    if (!definedPrograms.Contains(isim, StringComparison.OrdinalIgnoreCase)) continue;

                    var isim2 = process.ProcessName;
                    if (!definedPrograms.Contains(isim2, StringComparison.OrdinalIgnoreCase)) continue;

                    try { process.Kill(); } catch { }

                    closeFivem();

                    HackSend(isim.Trim().ToLower().Replace(" ", "_"));
                }
            });
        }


        public void closeFivem()
        {
            foreach (var process in Process.GetProcessesByName("FiveM"))
            {
                try { process.Kill(); } catch { }
            }
        }

        public void connectFivem(string ipNumber, string portNumber)
        {
            steamCalissiyormu();
            Process.Start($"fivem://connect/{ipNumber}:{portNumber}");
        }

        public void open(string link)
        {
            try
            {
                Process.Start(link);
            }
            catch (Exception)
            {
                MessageBox.Show("Bir sorunla karşılaşıldı Linkac komutundu.");
            }
        }

        public void discordMsg(string url, string msg)
        {
            try
            {
                _ = Post(url, new NameValueCollection { { "username", jsonClass.discordbot }, { "avatar_url", jsonClass.avatarurl }, { "content", msg } });
            }
            catch (Exception)
            {
                MessageBox.Show(@"Çok fazla istek gönderildi. Üst üste bu kadar mesaj gönderemezsiniz.");
            }
        }

        public void DicordRC(string serverName, string secMsg, string thirdMsg)
        {
            try
            {
                Setup();

                Update();

                Client.SetPresence(new RichPresence
                {
                    Details = serverName,
                    State = secMsg,
                    Assets = new Assets { LargeImageKey = jsonClass.discordRCbuyukResim, LargeImageText = thirdMsg, SmallImageKey = jsonClass.discordRCkucukResim }
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
                var sayi = Convert.ToInt64(hexid.Trim());
                var b = Convert.ToString(sayi, 16);
                var c = "steam:" + b;
                Properties.Settings.Default.steamid = c;
                Properties.Settings.Default.Save();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen Sadece Steam64ID nizi giriniz. \n Pls make sure write steam64 id !", "Steam ID Hatası");
            }
        }
        public void cacheDelete()
        {
            try
            {
                var processes = Process.GetProcesses();
                var array = processes;
                var num = array.Sum(process => process.WorkingSet64);
                var array2 = processes;

                foreach (var process2 in array2)
                {
                    try { EmptyWorkingSet(process2.Handle); } catch { }
                }

                processes = Process.GetProcesses();
                var array3 = processes;
                num = array3.Sum(process3 => process3.WorkingSet64);
            }
            catch (Exception)
            {


            }
        }

        public void playSound(String soundName)
        {
            try
            {
                var player = new SoundPlayer();
                var path = $"{Environment.CurrentDirectory}\\{soundName}"; // Çalmasini istediginiz ses dosyasinin yolu
                player.SoundLocation = path;
                player.Play();
            }
            catch (Exception)
            {

                MessageBox.Show("Müzik Dosyası Bulunamadı.\nFile not found", BaslikHatalar);
            }
        }

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
                    ini.VeriYaz("Ayarlar", "Ad", AppDomain.CurrentDomain.FriendlyName);
                    ini.VeriYaz("Ayarlar", "Version", Application.ProductVersion);
                    ini.VeriYaz("Ayarlar", "YeniVersion", jsonClass.version);
                    ini.VeriYaz("Ayarlar", "indirilicekAdres", jsonClass.guncellemelink);
                    var dizinYolu = Path.GetDirectoryName(Application.ExecutablePath);
                    var dosyaAdi = dizinYolu + "\\FiveMCodeUpdater.exe";
                    Process.Start(dosyaAdi);
                    Environment.Exit(1);
                }
            }
            catch { }
        }
        public void connectWithPanel(String serverkey)
        {
            try
            {
                steamCalissiyormu();
                kayitliSteamid = SteamLogin();
                steamnewid = Steam32ToSteam64(SteamLogin());
                var sayi = Convert.ToInt64(steamnewid);
                var b = Convert.ToString(sayi, 16);
                var value = "steam:" + b;

                if (jsonClass.ip == "")
                {
                    serverinfos(serverkey);
                }


                if (jsonClass.whitelist == "yok")
                {
                    const string durum = "1";
                    var sonucKayit = connectionOutSide.getRegister(s.luncherReg_url, serverkey, value, steamnewid.ToString(), durum);

                    if (sonucKayit == "")
                    {
                        var sonucKayit2 = connectionOutSide.getRegister(s.apiv2reg_url, serverkey, value, steamnewid.ToString(), durum);

                        if (sonucKayit2 == "")
                        {
                            var sonucKayit3 = connectionOutSide.getRegister(s.apiv3reg_url, serverkey, value, steamnewid.ToString(), durum);
                        }
                    }



                    Process.Start($"fivem://connect/{jsonClass.ip}:{jsonClass.port}");
                }
                else
                {
                    const string durum = "3";
                    var sonuc = connectionOutSide.getRegister(s.luncherReg_url, serverkey, value, steamnewid.ToString(), durum);

                    if (sonuc == "")
                    {
                        var sonuc2 = connectionOutSide.getRegister(s.apiv2reg_url, serverkey, value, steamnewid.ToString(), durum);

                        if (sonuc2 == "")
                        {
                            var sonuc3 = connectionOutSide.getRegister(s.apiv3reg_url, serverkey, value, steamnewid.ToString(), durum);
                        }
                    }
                    Process.Start($"fivem://connect/{jsonClass.ip}:{jsonClass.port}");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Panel ile iletişim kurulurken bir sorunla karşılaştık.", "FivemCode System", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private string SteamLogin()
        {
            return $"U:1:{Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam\\ActiveProcess")?.GetValue("ActiveUser")}";
        }

        private string DecimalToHexadecimal(long dec)
        {
            try
            {
                if (dec < 1) return "0";

                var hex = dec;
                var hexStr = string.Empty;

                while (dec > 0)
                {
                    hex = dec % 16;
                    hexStr = hexStr.Insert(0, hex < 10 ? Convert.ToChar(hex + 48).ToString() : Convert.ToChar(hex + 55).ToString());
                    dec /= 16;
                }

                return hexStr.ToLower();
            }
            catch (Exception)
            {
                return "0";
            }
        }

        private static byte[] Post(string uri, NameValueCollection pairs)
        {
            using (var webClient = new WebClient())
            {
                return webClient.UploadValues(uri, pairs);
            }
        }

        private void steamCalissiyormu()
        {
            var processlist = Process.GetProcesses();

            var steamWebHelperProcess = false;
            var steamServiceProcess = false;
            foreach (var theprocess in processlist)
            {
                switch (theprocess.ProcessName)
                {
                    case "steamwebhelper":
                        steamWebHelperProcess = true;
                        break;
                    case "SteamService":
                        steamServiceProcess = true;
                        break;
                }
            }

            if (steamWebHelperProcess && steamServiceProcess) return;

            MessageBox.Show("Please open steam or login steam. \nLütfen steaminizi açın veya giriş yapın.", BaslikHatalar);
            closeFivem();
        }

        private static long Steam32ToSteam64(string input)
        {
            try
            {
                var steam32 = Convert.ToInt64(input.Substring(4));
                if (steam32 < 1L || !Regex.IsMatch($"U:1:{steam32.ToString(CultureInfo.InvariantCulture)}", "^U:1:([0-9]{1,10})$"))
                {
                    return 0;
                }
                return steam32 + 76561197960265728L;
            }
            catch
            {
                return 0;
            }
        }

        private void HackSend(string postalanicak)
        {
            if (string.IsNullOrWhiteSpace(postalanicak)) return;

            var sonuc = connectionOutSide.getPostHack(s.apihack_url, _serverkey, steamnewid.ToString(), postalanicak);
            if (sonuc) return;

            var sonuc2 = connectionOutSide.getPostHack(s.api2hack_url, _serverkey, steamnewid.ToString(), postalanicak);
            if (sonuc2) return;

            var sonuc3 = connectionOutSide.getPostHack(s.api2hack_url, _serverkey, steamnewid.ToString(), postalanicak);
        }
    }
}