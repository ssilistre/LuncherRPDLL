using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace fivemLuncher
{
    class connectionOutSide
    {
        internal static bool getPost(String url,String serverkey)
        {
            bool flag = false;
           
            HttpWebRequest request = WebRequest.Create(url + serverkey) as HttpWebRequest;
            request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml,         image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            request.Headers["Accept-Language"] = "tr-TR";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;
            request.Timeout = 10000;
            request.Method = "POST";

            try
            {

         
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    String jsonVerisi = reader.ReadToEnd();
                    jsonClass _json = JsonConvert.DeserializeObject<jsonClass>(jsonVerisi);
                    flag = true;
                }
                return flag;
            }
            catch (Exception)
            {

                return flag;
            }
        }

        internal static string getRegister(String url,String serverkey,String value,String steamnewid,String Durum)
        {
            string SteamUserName = "";
             
            HttpWebRequest sunucubaglan = WebRequest.Create(url + serverkey + "&steamhexid=" + value + "&steam64id=" + steamnewid + "&online=0&durum="+Durum) as HttpWebRequest;
            sunucubaglan.Headers["Accept-Language"] = "tr-TR";
            sunucubaglan.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            sunucubaglan.KeepAlive = true;
            sunucubaglan.AllowAutoRedirect = true;
            sunucubaglan.Timeout = 10000;
            sunucubaglan.Method = "POST";

            try
            {
                using (HttpWebResponse sunucuyanit = sunucubaglan.GetResponse() as HttpWebResponse)
                {

                    StreamReader okuyucu = new StreamReader(sunucuyanit.GetResponseStream());
                    SteamUserName = okuyucu.ReadToEnd();
                    return SteamUserName;
                }
            }
            catch (Exception)
            {

                return SteamUserName;
            }

        }

        internal static bool getPostHack(string url, string serverkey,string steamid64,string dosya)
        {
            bool flag = false;
            HttpWebRequest request = WebRequest.Create(url + serverkey+ "&steam64id=" + steamid64+ "&hileadi=" + dosya) as HttpWebRequest;
            request.Accept = "application/x-ms-application, image/jpeg, application/xaml+xml,         image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            request.Headers["Accept-Language"] = "tr-TR";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            request.KeepAlive = true;
            request.AllowAutoRedirect = true;
            request.Timeout = 10000;
            request.Method = "POST";

            try
            {


                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {

                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    String jsonVerisi = reader.ReadToEnd();
                    flag = true;
                }
                return flag;
            }
            catch (Exception)
            {

                return flag;
            }
        }
    }
}
