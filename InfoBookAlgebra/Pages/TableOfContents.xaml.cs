using System.Windows.Controls;

namespace InfoBookAlgebra.Pages
{
    /// <summary>
    /// Логика взаимодействия для TableOfContents.xaml
    /// </summary>
    public partial class TableOfContents : Page
    {
        public TableOfContents()
        {
            InitializeComponent();

            DataContext = new TableOfContentsViewModel();
        }
    }
}
