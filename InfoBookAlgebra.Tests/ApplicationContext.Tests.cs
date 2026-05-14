using InfoBookAlgebraCore;

namespace InfoBookAlgebra.Tests
{
    public class ApplicationContextTests
    {
        private ApplicationContext _context;

        [SetUp]
        public void Setup()
        {
            _context = ApplicationContext.GetInstance();
        }

        [TearDown]
        public void TearItDown()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        [Test]
        public void Test_AddTheme_ReturnsOne()
        {
            var theme = new Theme { Name = "MyTheme" };

            _context.AddTheme(theme, "Content for my theme");

            var themes = _context.GetThemes();

            Assert.That(themes.Count == 1, $"Theme count: {themes.Count}");
        }

        [Test]
        public void Test_AddTheme_ThrowsExceptionByTheme()
        {
            var theme = new Theme { Name = null }; // This should cause an exception

            Assert.Catch(() =>
            {
                _context.AddTheme(theme, "Content for my theme");
            });
        }

        [Test]
        public void Test_AddTheme_ThrowsExceptionByThemeContent()
        {
            var theme = new Theme { Name = "My Theme" };
            string content = null; // This should cause an exception

            Assert.Catch(() =>
            {
                _context.AddTheme(theme, content);
            });
        }

        [Test]
        public void Test_GetInstance_ShouldNotBeNull()
        {
            var db = ApplicationContext.GetInstance();

            Assert.That(db != null, "Instance is null");
        }
    }
}