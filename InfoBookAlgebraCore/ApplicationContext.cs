using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace InfoBookAlgebraCore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<ThemeContent> ThemeContents { get; set; }

        public ApplicationContext()
        {
            // test
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=algebra2;Username=postgres;Password=sa");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Theme>()
                .HasOne(t => t.Content)
                .WithOne(c => c.Theme)
                .HasForeignKey<ThemeContent>(tc => tc.ThemeId);
        }
    }
}
