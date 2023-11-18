using System.Text.Json.Serialization;

namespace College_Sports_WebApp.Database.Models{ 

    public class Market
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string type { get; set; }
    }

}