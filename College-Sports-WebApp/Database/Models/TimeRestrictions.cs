using System; 
namespace College_Sports_WebApp.Database.Models{ 

    public class TimeRestrictions
    {
        public DateTime embargoDate { get; set; }
        public DateTime expirationDate { get; set; }
    }

}