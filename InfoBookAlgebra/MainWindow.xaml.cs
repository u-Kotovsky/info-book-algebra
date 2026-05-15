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

        #region Singleton stuff
        private static MainWindow _instance;
        /// <summary>
        /// Get current instance
        /// </summary>
        /// <returns></returns>
        public static MainWindow GetInstance()
        {
            return _instance;
        }
        #endregion

        /// <summary>
        /// Main constructor
        /// </summary>
        public MainWindow()
        {
            _instance = this;

            InitializeComponent();

            OpenTableOfContents();
        }

        #region Navigation stuff
        /// <summary>
        /// Navigates MainFrame to Table of Contents
        /// </summary>
        public void OpenTableOfContents()
        {
            if (tableOfContents == null)
            {
                tableOfContents = new TableOfContents();
            }

            MainFrame.Navigate(tableOfContents);
        }

        /// <summary>
        /// Navigates MainFrame to ContentPage with selected theme
        /// </summary>
        /// <param name="theme"></param>
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
        #endregion
    }
}