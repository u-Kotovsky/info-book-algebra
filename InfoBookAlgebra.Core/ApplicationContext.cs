using System.Text;
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
#if !THIS_IS_A_TEST 
                // We do not want this to interfer with the tests. They have to be isolated process.
                // Add default values

                _instance.AddTheme(new Theme("Понятие алгебраической дроби"), "Алгебраическая дробь — это дробь, в которой числитель и знаменатель являются алгебраическими выражениями, то есть многочленами (а также одночленами). Дробная черта означает деление числителя на знаменатель. ");
                _instance.AddTheme(new Theme("Упрощение рациональных выражений"), "Упрощение рациональных выражений — это применение тождественных преобразований с целью сделать запись выражения короче и удобнее для дальнейшей работы. Рациональное выражение — это алгебраическое выражение, не содержащее корней и включающее только действия сложения, вычитания, умножения, деления и возведения в степень. Рациональная дробь — это дробь, числитель и знаменатель которой — многочлены");
                _instance.AddTheme(new Theme("Понятие квадратного корня"), "Квадратный корень — одно из фундаментальных понятий в математике, которое используется в вычислениях, геометрии, алгебре и других областях.");
#if !RELEASE
                var theme4 = new Theme("Длинная тема тест");
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < 128; i++)
                {
                    builder.Append($"{i} Very long content will be there");
                }
                _instance.AddTheme(theme4, builder.ToString());
#endif
#endif
            }

            return _instance;
        }
#endregion

        private ApplicationContext(bool forceMemoryOnly = false)
        {
            ForceMemoryOnly = forceMemoryOnly;

            // tl;dr do not use in production, probably
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

            // local data?
            //optionsBuilder.UseSqlite("data.sqlite");
        }
        #endregion

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
