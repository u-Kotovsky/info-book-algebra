using System.Windows.Controls;
using InfoBookAlgebraCore;

namespace InfoBookAlgebra.Pages
{
    /// <summary>
    /// Логика взаимодействия для TableOfContents.xaml
    /// </summary>
    public partial class TableOfContents : Page
    {
        private ApplicationContext _context;

        // Display list of available themes
        public TableOfContents()
        {
            InitializeComponent();

            _context = ApplicationContext.GetInstance();

            contentsGrid.ItemsSource = _context.GetThemes();
        }
    }
}
