using Microsoft.EntityFrameworkCore;

namespace InfoBookAlgebraCore
{
    /// <summary>
    /// A class that stores current Database context 
    /// and handles basic requests.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        private DbSet<Theme> Themes { get; set; }
        private DbSet<ThemeContent> ThemeContents { get; set; }

        private bool ForceMemoryOnly { get; set; }

        #region Singleton
        private static ApplicationContext? _instance;

        /// <summary>
        /// Get active instance of ApplicationContext
        /// </summary>
        /// <returns></returns>
        public static ApplicationContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ApplicationContext();
            }

            return _instance;
        }
#endregion

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="forceMemoryOnly"></param>
        private ApplicationContext(bool forceMemoryOnly = false)
        {
            ForceMemoryOnly = forceMemoryOnly;
        }

        /// <summary>
        /// Configure database connection
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (ForceMemoryOnly)
            {
                optionsBuilder.UseInMemoryDatabase("DevelopmentDb");
            } 
            else
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=algebra2;Username=postgres;Password=sa");
            }
        }

        #region Helpers
        /// <summary>
        /// Get current list of themes
        /// </summary>
        /// <returns></returns>
        public List<Theme> GetThemes()
        {
            return Themes.ToList();
        }

        /// <summary>
        /// Get content by selected theme
        /// </summary>
        /// <param name="theme"></param>
        /// <returns></returns>
        public ThemeContent? GetContentByTheme(Theme theme)
        {
            return ThemeContents.Where(tc => tc.ThemeId == theme.Id).FirstOrDefault();
        }

        /// <summary>
        /// Add multiple themes
        /// </summary>
        /// <param name="values"></param>
        public void AddThemeRange(params Theme[] values)
        {
            foreach (var value in values)
            {
                AddTheme(value, "Content to be added");
            }
        }

        /// <summary>
        /// Add multiple themes
        /// </summary>
        /// <param name="values"></param>
        public void AddThemeRange(params (Theme, string)[] values)
        {
            foreach (var value in values)
            {
                AddTheme(value.Item1, value.Item2);
            }
        }

        /// <summary>
        /// Add theme to the list
        /// </summary>
        /// <param name="theme"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
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
            SaveChanges(); // Only after saving changes DB applies generated ID to the entity

            var themeContent = new ThemeContent(content, theme.Id);
            ThemeContents.Add(themeContent);

            SaveChanges();

            return (theme, themeContent); 
        }
        #endregion
    }
}
