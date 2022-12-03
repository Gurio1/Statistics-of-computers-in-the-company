using System;
using System.Windows.Input;
using WPF_46731r.ViewModels;

namespace WPF_46731r.State.Navigators
{
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        event Action CurrentFormChanged;
    }
}
