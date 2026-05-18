using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace InfoBookAlgebra.Helpers
{
    public abstract class NotifablePropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
