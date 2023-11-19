using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Ad
    {
        public string sport { get; set; }
        public string bundle { get; set; }
    }

}