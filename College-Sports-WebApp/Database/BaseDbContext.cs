using College_Sports_WebApp.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace College_Sports_WebApp.Database
{
    public class BaseDbContext : DbContext
    {
        public DbSet<ScoreboardResult> ScoreboardResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var stringListConverter = new ValueConverter<List<string>, string>(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());

            var stringListComparer = new ValueComparer<List<string>>(
                (x, y) => x.SequenceEqual(y),
                x => x.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                x => x.ToList());

            modelBuilder.Entity<Broadcast>()
                .Property(e => e.names)
                .HasConversion(stringListConverter, stringListComparer);

            modelBuilder.Entity<DeviceRestrictions>()
                .Property(e => e.devices)
                .HasConversion(stringListConverter, stringListComparer);

            modelBuilder.Entity<League>()
                .Property(e => e.calendar)
                .HasConversion(stringListConverter, stringListComparer);

            modelBuilder.Entity<Link>()
                .Property(e => e.rel)
                .HasConversion(stringListConverter, stringListComparer);

            modelBuilder.Entity<Logo>()
                .Property(e => e.rel)
                .HasConversion(stringListConverter, stringListComparer);

            modelBuilder.Entity<Properties>()
                .Property(e => e.dtcPackages)
                .HasConversion(stringListConverter, stringListComparer);

            modelBuilder.Entity<Properties>()
                .Property(e => e.iso3166)
                .HasConversion(stringListConverter, stringListComparer);

            modelBuilder.Entity<Properties>()
                .Property(e => e.subscription)
                .HasConversion(stringListConverter, stringListComparer);

            modelBuilder.Entity<ScoreboardResult>()
                .Property(e => e.groups)
                .HasConversion(stringListConverter, stringListComparer);

            modelBuilder.Entity<Video>()
                .Property(e => e.keywords)
                .HasConversion(stringListConverter, stringListComparer);

            modelBuilder.Entity<ViewingPolicy>()
                .Property(e => e.actions)
                .HasConversion(stringListConverter, stringListComparer);
        }
    }
}