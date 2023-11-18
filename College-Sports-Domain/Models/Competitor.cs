using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace College_Sports_WebApp.Database.Models{ 

    public class Competitor
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string uid { get; set; }
        public string type { get; set; }
        public int order { get; set; }
        public string homeAway { get; set; }
        public Team team { get; set; }
        public string score { get; set; }
        public List<Linescore> linescores { get; set; }
        public List<Statistic> statistics { get; set; }
        public List<Leader> leaders { get; set; }
        public CuratedRank curatedRank { get; set; }
        public List<Record> records { get; set; }
    }

}