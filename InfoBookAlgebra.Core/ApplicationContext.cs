using Microsoft.EntityFrameworkCore;

namespace InfoBookAlgebraCore
{
    // Singleton technically
    public class ApplicationContext : DbContext
    {
        private DbSet<Theme> Themes { get; set; }
        private DbSet<ThemeContent> ThemeContents { get; set; }

        private bool ForceMemoryOnly { get; set; }

        #region Singleton
        private static ApplicationContext? _instance;
        public static ApplicationContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ApplicationContext();
            }

            return _instance;
        }
        #endregion

        private ApplicationContext(bool forceMemoryOnly = false)
        {
            this.ForceMemoryOnly = forceMemoryOnly;
            // test
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        #region Database Setup
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
            /*modelBuilder
                .Entity<Theme>()
                .HasOne(t => t.Content)
                .WithOne(c => c.Theme)
                .HasForeignKey<ThemeContent>(tc => tc.ThemeId);*/
        }
        #endregion

        #region Helpers

        public List<Theme> GetThemes()
        {
            return Themes.ToList();
        }

        public ThemeContent? GetContentByTheme(Theme theme)
        {
            return ThemeContents.Where(tc => tc.ThemeId == theme.Id).FirstOrDefault();
        }

        public (Theme, ThemeContent) AddTheme(Theme theme, string content = "Content to be added")
        {
            if (theme == null)
            {
                throw new NullReferenceException("Theme cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(theme.Name))
            {
                throw new NullReferenceException("Theme name cannot be null or empty.");
            }

            if (content == null)
            {
                throw new NullReferenceException("Content cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                throw new NullReferenceException("Content should have actual content, not null or whitespace.");
            }

            Themes.Add(theme);
            SaveChanges(); // Only after saving changes DB applies ID to the entity

            var themeContent = new ThemeContent { Content = content, ThemeId = theme.Id };
            ThemeContents.Add(themeContent);

            SaveChanges();

            return (theme, themeContent); 
        }

        public void SetThemeContent()
        {

        }

        #endregion
    }
}
