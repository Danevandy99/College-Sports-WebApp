using College_Sports_Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database
{
    public class BaseDbContext : DbContext
    {
        public DbSet<ScoreboardFetch> ScoreboardFetches { get; set; }

        public DbSet<ConferencesFetch> ConferencesFetches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}