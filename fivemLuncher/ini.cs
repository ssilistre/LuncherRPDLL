using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace fivemLuncher
{
    public static class ini
    {
        //Sınıfımızı Extension Method olarak kullanmak istediğimiz için static tanımlıyoruz.

        static string dizinYolu = Path.GetDirectoryName(Application.ExecutablePath);
        static string dosyaAdi = $"{dizinYolu}\\ayarlar.ini";


        //Yazma işlemleri için gerekli olan dll'i import edip, ini için WritePrivateProfileString metodunun görüntüsünü aldık
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool WritePrivateProfileString(string kategori, string anahtar, string deger, string dosyaAdi);


        //Yazma işlemleri için gerekli olan dll'i import edip, ini için GetPrivateProfileString metodunun görüntüsünü aldık
        [DllImport("kernel32.dll")]
        static extern uint GetPrivateProfileString(string kategori, string anahtar, string lpDefault, StringBuilder sb, int sbKapasite, string dosyaAdi);

        public static bool VeriYaz(string kategori, string anahtar, string deger)
        {
            if (!Directory.Exists(dizinYolu)) //Dizin yoksa oluşturalım.
                Directory.CreateDirectory(dizinYolu);

            return WritePrivateProfileString(kategori, anahtar, deger, dosyaAdi);
        }

        public static string VeriOku(string kategori, string anahtar)
        {
            //Okunacak veriyi okumak ve kapasitesini sınırlandırmak ve performans için StringBuilder sınıfını kullanıyoruz.
            var sb = new StringBuilder(500);

            GetPrivateProfileString(kategori, anahtar, string.Empty, sb, sb.Capacity, dosyaAdi);

            var veri = sb.ToString();
            sb.Clear();
            return veri;
        }
    }
}
