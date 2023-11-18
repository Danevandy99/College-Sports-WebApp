using System.Collections.Generic; 
namespace College_Sports_WebApp.Database.Models{ 

    public class ViewingPolicy
    {
        public Audience audience { get; set; }
        public List<string> actions { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string externalId { get; set; }
    }

}