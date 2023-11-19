using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Position
    {
        public string abbreviation { get; set; }
    }

}