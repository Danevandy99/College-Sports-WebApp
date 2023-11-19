using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
namespace College_Sports_WebApp.Database.Models
{

    public class LastPlay
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public long id { get; set; }
        public required LastPlayType type { get; set; }
        public required string text { get; set; }
        public int scoreValue { get; set; }
        //public Team team { get; set; }
        public required Probability probability { get; set; }
        public List<AthletesInvolved> athletesInvolved { get; set; } = new List<AthletesInvolved>();
    }

    [Owned]
    public class LastPlayType
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public required string text { get; set; }
    }
}