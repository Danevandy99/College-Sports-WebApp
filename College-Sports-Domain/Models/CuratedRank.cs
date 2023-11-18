using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class CuratedRank
    {
        public int current { get; set; }
    }

}