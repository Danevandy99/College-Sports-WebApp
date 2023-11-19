using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class ProductLinks
    {
        public string web { get; set; }
        public string mobile { get; set; }
    }

}