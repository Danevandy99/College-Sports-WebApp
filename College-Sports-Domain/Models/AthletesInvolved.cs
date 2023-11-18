using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace College_Sports_WebApp.Database.Models{ 

    public class AthletesInvolved
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public List<Link> links { get; set; }
        public string headshot { get; set; }
        public string jersey { get; set; }
        public string position { get; set; }
        public Team team { get; set; }
    }

}