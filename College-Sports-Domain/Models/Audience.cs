using System.Text.Json.Serialization;

namespace College_Sports_WebApp.Database.Models{ 

    public class Audience
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string externalId { get; set; }
        public string name { get; set; }
        public string match { get; set; }
        public Properties properties { get; set; }
    }

}