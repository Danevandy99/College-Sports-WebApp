namespace College_Sports_WebApp.Database.Models{ 

    public class Category
    {
        public int id { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int sportId { get; set; }
        public int athleteId { get; set; }
        public Athlete athlete { get; set; }
        public string uid { get; set; }
        public int? teamId { get; set; }
        public Team team { get; set; }
        public int? leagueId { get; set; }
        public League league { get; set; }
    }

}