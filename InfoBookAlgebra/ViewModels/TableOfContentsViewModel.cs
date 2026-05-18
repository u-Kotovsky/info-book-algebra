using System.Windows;
using InfoBookAlgebra.Core;
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

        #region Commands
        private RelayCommand? _getSqrtTableCommand;
        public RelayCommand GetSqrtTableCommand
        {
            get
            {
                return _getSqrtTableCommand ??= new RelayCommand(obj =>
                {
                    MessageBox.Show(string.Join(", ", MathSolver.GetSquareTable()),
                        "Таблица квадратов");
                });
            }
        }

        private VietteSolverWindow _vietteSolverWindow;
        private RelayCommand? _getVietteSolverCommand;
        public RelayCommand GetVietteSolverCommand
        {
            get
            {
                return _getVietteSolverCommand ??= new RelayCommand(obj =>
                {
                    _vietteSolverWindow ??= new VietteSolverWindow();
                    _vietteSolverWindow.Show();
                });
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
