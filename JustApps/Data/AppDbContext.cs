using System;
using JustApps.Models;
using Microsoft.EntityFrameworkCore;

namespace JustApps.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppInfo> AppsInfo { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}

