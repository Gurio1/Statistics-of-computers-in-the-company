using System.ComponentModel;

namespace WPF_46731r.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void Dispose() { }

        public void OnPropretyChanged(string propretyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propretyName));
        }
    }
}
