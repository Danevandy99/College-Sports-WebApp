using System.Text.Json.Serialization;

namespace College_Sports_WebApp.Database.Models{ 

    public class Audience
    {
        public string id { get; set; }
        public string externalId { get; set; }
        public string name { get; set; }
        public string match { get; set; }
        public Properties properties { get; set; }
    }

}