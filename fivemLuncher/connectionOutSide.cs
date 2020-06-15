using Newtonsoft.Json;
using System.Net;

namespace fivemLuncher
{
    class connectionOutSide
    {
        internal static bool getPost(string url, string serverKey)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var jsonVerisi = webClient.UploadString($"{url}{serverKey}", serverKey);
                    var _json = JsonConvert.DeserializeObject<jsonClass>(jsonVerisi);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static string getRegister(string url, string serverKey, string value, string steamNewId, string durum)
        {
            var steamUserName = string.Empty;

            try
            {
                using (var webClient = new WebClient())
                {
                    
                    steamUserName = webClient.UploadString($"{url}{serverKey}&steamhexid={value}&steam64id={steamNewId}&online=0&durum={durum}", $"{serverKey}&steamhexid={value}&steam64id={steamNewId}&online=0&durum={durum}");
                }
            }
            catch { }

            return steamUserName;
        }

        internal static bool getPostHack(string url, string serverKey, string steamId64, string dosya)
        {
            try
            {
                using (var webClient = new WebClient())
                {
                    var jsonVerisi = webClient.UploadString($"{url}{serverKey}&steam64id={steamId64}&hileadi={dosya}", $"{serverKey}&steam64id={steamId64}&hileadi={dosya}");
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
