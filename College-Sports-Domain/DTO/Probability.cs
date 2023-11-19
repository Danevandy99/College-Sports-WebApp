using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database.Models
{

    [Owned]
    public class Probability
    {
        public double tiePercentage { get; set; }
        public double homeWinPercentage { get; set; }
        public double awayWinPercentage { get; set; }
    }

}