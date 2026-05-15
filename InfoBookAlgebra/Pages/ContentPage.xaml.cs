using System.Windows;
using System.Windows.Controls;
using InfoBookAlgebraCore;

namespace InfoBookAlgebra.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContentPage.xaml
    /// </summary>
    public partial class ContentPage : Page
    {
        private ApplicationContext _context;

        private Theme? _currentTheme;
        private ThemeContent? _currentThemeContent;

        public ContentPage()
        {
            InitializeComponent();

            _context = ApplicationContext.GetInstance();
        }

        /// <summary>
        /// Opens current theme
        /// </summary>
        /// <param name="theme"></param>
        public void Open(Theme theme)
        {
            Title = theme.Name;

            _currentTheme = theme;
            _currentThemeContent = _context.GetContentByTheme(_currentTheme);

            TitleLabel.Content = _currentTheme.Name;
            ContentLabel.Content = _currentThemeContent.Content;
        }

        /// <summary>
        /// Resets whole page
        /// </summary>
        public void Reset()
        {
            TitleLabel.Content = string.Empty;
            ContentLabel.Content = string.Empty;

            _currentTheme = null;
            _currentThemeContent = null;
        }

        /// <summary>
        /// Opens previous theme if available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_BackClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TBD", "TBD", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            // TODO: check if there is available themes behind

            if (true)
            {
                return;
            }

            Reset();


        }

        /// <summary>
        /// Opens next theme if available.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_NextClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("TBD", "TBD", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            // TODO: check if there is available themes in front

            if (true)
            {
                return;
            }

            Reset();


        }
    }
}
