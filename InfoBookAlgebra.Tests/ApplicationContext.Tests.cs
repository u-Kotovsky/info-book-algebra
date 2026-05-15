#define THIS_IS_A_TEST

using InfoBookAlgebra.Core;
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
        public void Test_AddTheme_IsInList()
        {
            var theme = new Theme("MyTheme");

            _context.AddTheme(theme, "Content for my theme");

            var themes = _context.GetThemes().Count(x => x.Id == theme.Id);

            Assert.That(themes == 1, $"Theme count: {themes}");
        }

        [Test]
        public void Test_AddTheme_ThrowsExceptionByTheme()
        {
            var theme = new Theme(null); // This should cause an exception

            Assert.Catch(() =>
            {
                _context.AddTheme(theme, "Content for my theme");
            });
        }

        [Test]
        public void Test_AddTheme_ThrowsExceptionByThemeContent()
        {
            var theme = new Theme("My Theme");
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