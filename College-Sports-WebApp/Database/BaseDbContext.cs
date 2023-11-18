using College_Sports_WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database
{
    public class BaseDbContext : DbContext
    {
        public DbSet<PartialScoreboardResult> PartialScoreboardResults { get; set; }

        public DbSet<ScoreboardResult> ScoreboardResults { get; set; }
    }
}