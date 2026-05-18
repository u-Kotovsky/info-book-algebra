using InfoBookAlgebraCore;

namespace InfoBookAlgebra.Helpers
{
    /// <summary>
    /// Proxy-class to help MVVM with commands
    /// </summary>
    public class ThemeSelectable
    {
        public Theme ThemeData;

        public string Title
        {
            get { return ThemeData?.Name ?? "Couldn't load theme title"; }
        }

        public ThemeSelectable(Theme theme, Action<ThemeSelectable> onSelected = null)
        {
            ThemeData = theme;

            OnSelected += onSelected;
        }

        public event Action<ThemeSelectable> OnSelected = delegate { };

        private RelayCommand? _selectThemeCommand;
        public RelayCommand SelectThemeCommand
        {
            get
            {
                return _selectThemeCommand ??= new RelayCommand(obj =>
                {
                    OnSelected.Invoke(this);
                });
            }
        }
    }
}
