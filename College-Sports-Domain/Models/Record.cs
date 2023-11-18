using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{
    public class Record
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string abbreviation { get; set; }
        public string type { get; set; }
        public string summary { get; set; }
    }

}