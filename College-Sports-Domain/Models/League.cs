using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace College_Sports_WebApp.Database.Models{ 

    public class League
    {
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int id { get; set; }
        public string uid { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string midsizeName { get; set; }
        public string slug { get; set; }
        public LeagueSeason season { get; set; }
        public List<Logo> logos { get; set; }
        public string calendarType { get; set; }
        public bool calendarIsWhitelist { get; set; }
        public string calendarStartDate { get; set; }
        public string calendarEndDate { get; set; }
        public List<string> calendar { get; set; }
        public string href { get; set; }
    }

}