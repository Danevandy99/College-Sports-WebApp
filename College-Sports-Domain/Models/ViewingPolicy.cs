using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace College_Sports_WebApp.Database.Models{ 

    public class ViewingPolicy
    {
        public Audience audience { get; set; }
        public List<string> actions { get; set; }
        public string name { get; set; }

        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string externalId { get; set; }
    }

}