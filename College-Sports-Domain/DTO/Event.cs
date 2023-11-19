using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace College_Sports_WebApp.Database.Models{ 

    public class Event
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string uid { get; set; }
        public string date { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public Season season { get; set; }
        public List<Competition> competitions { get; set; }
        public List<Link> links { get; set; }
        public Status status { get; set; }
        public Weather weather { get; set; }
    }

}