using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace College_Sports_WebApp.Database
{
    public class BaseDbContext : DbContext
    {
        public DbSet<ScoreboardResult> ScoreboardResults { get; set; }
    }
}