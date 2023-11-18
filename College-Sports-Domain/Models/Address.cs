using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Address
    {
        public string city { get; set; }
        public string state { get; set; }
    }

}