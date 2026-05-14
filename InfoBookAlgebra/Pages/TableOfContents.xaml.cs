using System.Windows;
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

        private void contentsGrid_Selected(object sender, System.Windows.RoutedEventArgs e)
        {
            MessageBox.Show(e.Source.GetType().Name);
        }

        private void contentsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = contentsGrid.SelectedItem;
            if (selected is Theme)
            {
                MainWindow.GetInstance().OpenContentPage((Theme)selected);
            }
            else
            {
                throw new Exception("Selection is no theme but " + selected.GetType().Name);
            }
        }
    }
}
