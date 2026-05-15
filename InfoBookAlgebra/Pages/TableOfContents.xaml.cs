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

        public TableOfContents()
        {
            InitializeComponent();

            // Set current context instance
            _context = ApplicationContext.GetInstance();

            // Read all themes and set them into datagrid
            contentsGrid.ItemsSource = _context.GetThemes();
        }

        /// <summary>
        /// Opens selected theme in content page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
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
