using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Tracking
    {
        public string sportName { get; set; }
        public string leagueName { get; set; }
        public string coverageType { get; set; }
        public string trackingName { get; set; }
        public string trackingId { get; set; }
    }

}