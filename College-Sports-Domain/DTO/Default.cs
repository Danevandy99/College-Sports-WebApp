using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Default
    {
        public string href { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }

}