using System.Collections.Generic; 
namespace College_Sports_WebApp.Database.Models{ 

    public class LastPlay
    {
        public string id { get; set; }
        public Type type { get; set; }
        public string text { get; set; }
        public int scoreValue { get; set; }
        public Team team { get; set; }
        public Probability probability { get; set; }
        public List<AthletesInvolved> athletesInvolved { get; set; }
    }

}