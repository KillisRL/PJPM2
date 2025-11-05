
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MotoAPP.ViewModels
{
    public class BaseNotifyVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(
            [CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke
                (this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
