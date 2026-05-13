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

            // TODO: Load available themes from DB,
            // list them all in page as clickable
            // on click it will open a page that will load content for it.

            // test

            ApplicationContext? db = null;

            try 
            {
                db = new(true);
                
                var t1 = new Theme { Name = "Theme 1" };
                var t2 = new Theme { Name = "Theme 2" };

                var c1 = new ThemeContent { Content = "C 1", ThemeId = 1 };
                var c2 = new ThemeContent { Content = "C 2", ThemeId = 2 };

                db.Themes.AddRange(t1, t2);
                db.ThemeContents.AddRange(c1, c2);
                int result = db.SaveChanges();
                MessageBox.Show("Saved data " + result);

                var themes = db.Themes.ToList();
                var themes_string = string.Join(", ", themes.Select(x => $"{x.Name}_{x.CreatedAt.ToShortTimeString()}_{x.Content?.Content}"));
                MessageBox.Show("Theme list: " + themes_string);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Error", MessageBoxButton.OK);
            }
            finally
            {
                if (db != null)
                {
                    db.Dispose();
                }
            }
        }
    }
}