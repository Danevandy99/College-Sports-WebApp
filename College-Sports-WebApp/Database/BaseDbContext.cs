using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database
{
    public class BaseDbContext : DbContext
    {
        public DbSet<ScoreboardResult> ScoreboardResults { get; set; }
    }
}