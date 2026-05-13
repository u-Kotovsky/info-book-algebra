using Microsoft.EntityFrameworkCore;

namespace InfoBookAlgebraCore
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Theme> Themes { get; set; }
        public DbSet<ThemeContent> ThemeContents { get; set; }

        private bool ForceMemoryOnly { get; set; }

        public ApplicationContext(bool forceMemoryOnly = false)
        {
            this.ForceMemoryOnly = forceMemoryOnly;
            // test
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (ForceMemoryOnly)
            {
                optionsBuilder.UseInMemoryDatabase("DevelopmentDb");
            } 
            else
            {
                // this is still development database, but for now doesnt matter
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=algebra2;Username=postgres;Password=sa");
            }

            // local data
            //optionsBuilder.UseSqlite("data.sqlite");
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
