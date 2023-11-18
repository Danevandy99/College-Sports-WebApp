using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Situation
    {
        public LastPlay lastPlay { get; set; }
    }

}