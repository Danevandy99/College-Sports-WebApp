using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Format
    {
        public Regulation regulation { get; set; }
    }

}