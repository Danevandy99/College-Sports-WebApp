using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    public class Season
    {
        public int Id { get; set; }
        public int year { get; set; }
        public int type { get; set; }
        public string slug { get; set; }
    }

    public class LeagueSeason
    {
        public int Id { get; set; }
        public int year { get; set; }
        public required DateTime startDate { get; set; }
        public required DateTime endDate { get; set; }
        public required string displayName { get; set; }
        public required LeagueSeasonType type { get; set; }
    }

    [Owned]
    public class LeagueSeasonType
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }

        public int type { get; set; }

        public required string name { get; set; }

        public required string abbreviation { get; set; }
    }
}