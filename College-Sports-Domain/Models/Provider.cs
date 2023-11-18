using System.Text.Json.Serialization;

namespace College_Sports_WebApp.Database.Models{ 

    public class Provider
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string name { get; set; }
        public int priority { get; set; }
    }

}