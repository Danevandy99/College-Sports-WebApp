using System.Text.Json.Serialization;

namespace College_Sports_WebApp.Database.Models{ 

    public class Team
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string description { get; set; }
        public string uid { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string displayName { get; set; }
        public string shortDisplayName { get; set; }
        public string color { get; set; }
        public string alternateColor { get; set; }
        public bool isActive { get; set; }
        public Venue venue { get; set; }
        public string logo { get; set; }
        public string conferenceId { get; set; }
    }

}