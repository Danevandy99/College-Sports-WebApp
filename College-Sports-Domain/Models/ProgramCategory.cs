using System.Text.Json.Serialization;

namespace College_Sports_WebApp.Database.Models{ 

    public class ProgramCategory
    {
        public string artworkUrl { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string sportId { get; set; }
    }

}