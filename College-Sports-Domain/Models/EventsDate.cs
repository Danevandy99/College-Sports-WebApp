using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class EventsDate
    {
        public DateTime date { get; set; }
        public int seasonType { get; set; }
    }

}