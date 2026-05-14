using System.Windows;
using InfoBookAlgebra.Pages;
using InfoBookAlgebraCore;

namespace InfoBookAlgebra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TableOfContents tableOfContents;
        private ContentPage contentPage;

        private static MainWindow _instance;
        public static MainWindow GetInstance()
        {
            return _instance;
        }

        public MainWindow()
        {
            _instance = this;
            InitializeComponent();

            // TODO: Load available themes from DB,
            // list them all in page as clickable
            // on click it will open a page that will load content for it.

            OpenTableOfContents();
        }

        public void OpenTableOfContents()
        {
            if (tableOfContents == null)
            {
                tableOfContents = new TableOfContents();
            }
            MainFrame.Navigate(tableOfContents);
        }

        public void OpenContentPage(Theme theme)
        {
            if (contentPage == null)
            {
                contentPage = new ContentPage();
            }
            else
            {
                contentPage.Reset();
            }

            contentPage.Open(theme);

            MainFrame.Navigate(contentPage);
        }
    }
}