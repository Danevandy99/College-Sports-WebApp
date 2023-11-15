using Microsoft.EntityFrameworkCore;

public class CustomDbContext : DbContext
{
    public DbSet<ScoreboardResult> ScoreboardResults { get; set; }

    public string DbPath { get; }

    public CustomDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "college-sports.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}