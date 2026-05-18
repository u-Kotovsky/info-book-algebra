using System.Windows.Controls;

namespace InfoBookAlgebra.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContentPage.xaml
    /// </summary>
    public partial class ContentPage : Page
    {
        public ContentPage()
        {
            InitializeComponent();

            DataContext = new ContentPageViewModel();
        }
    }
}
