using System.Windows;
using InfoBookAlgebra.ViewModels;

namespace InfoBookAlgebra
{
    /// <summary>
    /// Логика взаимодействия для VietteSolverWindow.xaml
    /// </summary>
    public partial class VietteSolverWindow : Window
    {
        public VietteSolverWindow()
        {
            InitializeComponent();

            DataContext = new VietteSolverViewModel();
        }
    }
}
