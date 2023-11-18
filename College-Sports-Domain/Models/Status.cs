using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Status
    {
        public double clock { get; set; }
        public string displayClock { get; set; }
        public int period { get; set; }
        public Type type { get; set; }
    }

}