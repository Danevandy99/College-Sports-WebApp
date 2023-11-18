using System.Collections.Generic; 
namespace College_Sports_WebApp.Database.Models{ 

    public class AthleteLinks
    {
        public Api api { get; set; }
        public Web web { get; set; }
        public Mobile mobile { get; set; }
        public Source source { get; set; }
    }

}