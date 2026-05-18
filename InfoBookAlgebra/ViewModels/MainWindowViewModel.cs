using System.Windows;
using InfoBookAlgebra.Core;
using InfoBookAlgebra.Helpers;
using InfoBookAlgebra.Pages;

namespace InfoBookAlgebra
{
    public class MainWindowViewModel : NotifablePropertyChanged
    {
        private TableOfContents? tableOfContents;

        private MainWindow _mainWindow;

        public MainWindowViewModel()
        {
            _mainWindow = MainWindow.GetInstance();

            OpenTableOfContents();

            MessageBox.Show(string.Join(", ", MathSolver.GetSquareTable()));
        }

        /// <summary>
        /// Navigates MainFrame to Table of Contents
        /// </summary>
        public void OpenTableOfContents()
        {
            tableOfContents ??= new TableOfContents();

            _mainWindow.MainFrame.Navigate(tableOfContents);
        }
    }
}