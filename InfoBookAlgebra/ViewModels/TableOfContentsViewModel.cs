using System.Windows;
using InfoBookAlgebra.Helpers;
using InfoBookAlgebraCore;

namespace InfoBookAlgebra.Pages
{
    /// <summary>
    /// Displays a list of available themes and lets user open them.
    /// </summary>
    public class TableOfContentsViewModel : NotifablePropertyChanged
    {
        private ApplicationContext _context;
        private MainWindow _mainWindow;

        private ContentPage? contentPage;

        #region Properties
        public List<ThemeSelectable>? _currentThemes;
        public List<ThemeSelectable> CurrentThemes
        {
            get { return _currentThemes ?? (_currentThemes = new List<ThemeSelectable>()); }
            set
            {
                _currentThemes = value;
                OnPropertyChanged(nameof(CurrentThemes));
            }
        }
        #endregion

        public TableOfContentsViewModel()
        {
            // Put objects in cache for quick access
            _context = ApplicationContext.GetInstance();
            _mainWindow = MainWindow.GetInstance();

            PopulateThemes(_context.GetThemes());
        }

        /// <summary>
        /// Populates CurrentThemes property
        /// </summary>
        /// <param name="themes"></param>
        public void PopulateThemes(List<Theme> themes)
        {
            List<ThemeSelectable> selectables = [];

            foreach (var theme in themes)
            {
                selectables.Add(new ThemeSelectable(theme, OnThemeSelected));
            }

            CurrentThemes = selectables;
        }

        private void OnThemeSelected(ThemeSelectable theme)
        {
            contentPage ??= new ContentPage();

            (contentPage.DataContext as ContentPageViewModel)?.Open(theme.ThemeData);

            _mainWindow.MainFrame.Navigate(contentPage);
        }
    }
}
