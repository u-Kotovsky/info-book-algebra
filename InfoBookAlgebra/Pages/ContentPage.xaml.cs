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

        // Display selected theme content
        public ContentPage()
        {
            InitializeComponent();

            _context = ApplicationContext.GetInstance();
        }

        public void Open(Theme theme)
        {
            _currentTheme = theme;
            _currentThemeContent = _context.GetContentByTheme(_currentTheme);

            TitleLabel.Content = _currentTheme.Name;
            ContentLabel.Content = _currentThemeContent.Content;
        }

        public void Reset()
        {
            TitleLabel.Content = string.Empty;
            ContentLabel.Content = string.Empty;
        }

        private void Button_BackClick(object sender, RoutedEventArgs e)
        {
            // TODO: check if there is available themes behind

            Reset();


        }

        private void Button_NextClick(object sender, RoutedEventArgs e)
        {
            // TODO: check if there is available themes in front

            Reset();


        }
    }
}
