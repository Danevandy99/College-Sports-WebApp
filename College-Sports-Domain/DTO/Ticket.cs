using System.Collections.Generic; 
namespace College_Sports_WebApp.Database.Models{ 

    public class Ticket
    {
        public int Id { get; set; }
        public string summary { get; set; }
        public int numberAvailable { get; set; }
        public List<Link> links { get; set; }
    }

}