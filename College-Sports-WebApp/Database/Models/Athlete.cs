namespace College_Sports_WebApp.Database.Models{ 

    public class Athlete
    {
        public int id { get; set; }
        public string description { get; set; }
        public AthleteLinks links { get; set; }
        public string fullName { get; set; }
        public string displayName { get; set; }
        public string shortName { get; set; }
        public string headshot { get; set; }
        public string jersey { get; set; }
        public Position position { get; set; }
        public Team team { get; set; }
        public bool active { get; set; }
    }

}