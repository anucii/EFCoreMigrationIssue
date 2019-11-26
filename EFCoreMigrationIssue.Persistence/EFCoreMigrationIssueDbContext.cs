using System;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMigrationIssue.Persistence
{
    public class EFCoreMigrationIssueDbContext : DbContext
    {
        private string _databasePath;

        public EFCoreMigrationIssueDbContext(string databasePath)
        {
            _databasePath = databasePath;
            Database.Migrate();
        }

        public DbSet<Foo> Foos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Foo>().HasIndex(f => f.Uri)
                .IsUnique(true);
            base.OnModelCreating(modelBuilder);
        }
    }
}
