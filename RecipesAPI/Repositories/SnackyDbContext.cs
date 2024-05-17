using Microsoft.EntityFrameworkCore;
using SnackyAPI.Models.Database;
using SnackyAPI.Models.Database.Configuration;

namespace SnackyAPI.Repositories
{
    public class SnackyDbContext : DbContext
    {
        public string DbPath { get; }

        public DbSet<Snack> Snacks { get; set; }


        public SnackyDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "snacks.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SnackConfiguration());
            modelBuilder.ApplyConfiguration(new SnackCategoryConfiguration());
        }
    }
}
