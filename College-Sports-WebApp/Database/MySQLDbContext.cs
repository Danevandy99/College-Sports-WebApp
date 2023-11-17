using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database
{
    public class MySQLDbContext : BaseDbContext
    {
        private readonly IWebHostEnvironment? _environment;

        public MySQLDbContext()
        {

        }

        public MySQLDbContext(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStringFromEnvironment = Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb");

            if (connectionStringFromEnvironment is not null)
            {
                var dbhost = Regex.Match(connectionStringFromEnvironment, @"Data Source=(.+?);").Groups[1].Value;
                var server = dbhost.Split(':')[0].ToString();
                var port = dbhost.Split(':')[1].ToString();
                var dbname = Regex.Match(connectionStringFromEnvironment, @"Database=(.+?);").Groups[1].Value;
                var dbusername = Regex.Match(connectionStringFromEnvironment, @"User Id=(.+?);").Groups[1].Value;
                var dbpassword = Regex.Match(connectionStringFromEnvironment, @"Password=(.+?)$").Groups[1].Value;

                var connectionString = $@"server={server};userid={dbusername};password={dbpassword};database={dbname};port={port};pooling = false; convert zero datetime=True;";

                var serverVersion = ServerVersion.AutoDetect(connectionString);

                optionsBuilder.UseMySql(connectionString, serverVersion);
            }
            else if (_environment is not null && !_environment.IsDevelopment())
            {
                throw new Exception("MYSQLCONNSTR_localdb environment variable not found.");
            }
            else
            {
                // Random test version
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));

                // Test connection string
                optionsBuilder.UseMySql("server=localhost;user=root;password=1234;database=ef", serverVersion);
            }
        }
    }
}