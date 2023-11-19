using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Regulation
    {
        public int periods { get; set; }
    }

}