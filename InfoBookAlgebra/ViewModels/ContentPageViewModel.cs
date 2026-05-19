using InfoBookAlgebra.Helpers;
using InfoBookAlgebraCore;

namespace InfoBookAlgebra.Pages
{
    /// <summary>
    /// Displays current theme name, theme content.
    /// </summary>
    public class ContentPageViewModel : NotifablePropertyChanged
    {
        private ApplicationContext _context;

        #region Properties
        private Theme? _currentTheme;
        public Theme? CurrentTheme
        {
            get { return _currentTheme; }
            set
            {
                _currentTheme = value; 
                OnPropertyChanged(nameof(CurrentTheme));
                OnPropertyChanged(nameof(Title));
            }
        }

        private ThemeContent? _currentThemeContent;
        private ThemeContent? CurrentThemeContent
        {
            get { return _currentThemeContent; }
            set 
            { 
                _currentThemeContent = value;
                OnPropertyChanged(nameof(CurrentThemeContent));
                OnPropertyChanged(nameof(Content));
            }
        }

        public string Title { get { return CurrentTheme?.Name ?? "Failed to load title"; } set { } }
        public string Content { get { return CurrentThemeContent?.Content ?? "Failed to load content"; } set { } }
        #endregion

        #region Commands
        private RelayCommand? _backCommand;
        public RelayCommand BackCommand
        {
            get
            {
                return _backCommand ??= new RelayCommand(obj =>
                {
                    (_mainWindow.DataContext as MainWindowViewModel)?.OpenTableOfContents();
                });
            }
        }
        #endregion

        private MainWindow _mainWindow;

        /// <summary>
        /// Main constructor
        /// </summary>
        public ContentPageViewModel()
        {
            _context = ApplicationContext.GetInstance();
            _mainWindow = MainWindow.GetInstance();
        }

        /// <summary>
        /// Opens current theme
        /// </summary>
        /// <param name="theme"></param>
        public void Open(Theme theme)
        {
            CurrentTheme = theme;
            CurrentThemeContent = _context.GetContentByTheme(_currentTheme);
        }
    }
}
