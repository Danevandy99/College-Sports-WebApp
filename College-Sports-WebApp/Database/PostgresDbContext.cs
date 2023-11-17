using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database
{
    public class PostgresDbContext : BaseDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _environment;

        public PostgresDbContext(IConfiguration configuration, IWebHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("POSTGRESQLCONNSTR_AZURE_POSTGRESQL_CONNECTIONSTRING");

            if (string.IsNullOrEmpty(connectionString) && !_environment.IsDevelopment())
            {
                throw new Exception("Connection string is null or empty");
            }

            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}