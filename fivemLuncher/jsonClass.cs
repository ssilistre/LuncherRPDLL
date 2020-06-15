using Newtonsoft.Json;

namespace fivemLuncher
{
    class jsonClass
    {
        [JsonProperty("kontrolEdilicekler")]
        internal static string kontrolEdilicekler { get; set; }

        [JsonProperty("version")]
        internal static string version { get; set; }

        [JsonProperty("ip")]
        internal static string ip { get; set; }

        [JsonProperty("whitelist")]
        internal static string whitelist { get; set; }

        [JsonProperty("port")]
        internal static string port { get; set; }

        [JsonProperty("sunucu")]
        internal static string sunucu { get; set; }

        [JsonProperty("guncellemelink")]
        internal static string guncellemelink { get; set; }

        [JsonProperty("avatarurl")]
        internal static string avatarurl { get; set; }

        [JsonProperty("discordbot")]
        internal static string discordbot { get; set; }

        [JsonProperty("discordrc")]
        internal static string discordrc { get; set; }

        [JsonProperty("discordRCbuyukResim")]
        internal static string discordRCbuyukResim { get; set; }

        [JsonProperty("discordRCkucukResim")]
        internal static string discordRCkucukResim { get; set; }

        [JsonProperty("duyurular")]
        internal static string duyurular { get; set; }

        [JsonProperty("onlinekisi")]
        internal static int onlinekisi { get; set; }

    }
}
