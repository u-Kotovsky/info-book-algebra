using System.Windows;
using InfoBookAlgebraCore;

namespace InfoBookAlgebra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // test
            using (ApplicationContext db = new())
            {
                var t1 = new Theme { Name = "Theme 1" };
                var t2 = new Theme { Name = "Theme 2" };

                var c1 = new ThemeContent { Content = "C 1" };
                var c2 = new ThemeContent { Content = "C 2" };

                db.Themes.AddRange(t1, t2);
                db.ThemeContents.AddRange(c1, c2);
                db.SaveChanges();
                // todo: ensure entities have correct keys
                MessageBox.Show("Saved data");

                var themes = db.Themes.ToList();
                var themes_string = string.Join(", ", themes.Select(x => $"{x.Name}_{x.CreatedAt.ToShortTimeString()}_{x.Content?.Content}"));
                MessageBox.Show("Theme list: " + themes_string);
            }
        }
    }
}