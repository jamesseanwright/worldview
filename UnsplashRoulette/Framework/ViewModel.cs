using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UnsplashRoulette.Framework
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public virtual void OnNavigatedFrom()
        {
        }

        public virtual void OnNavigatedTo()
        {
        }
    }
}