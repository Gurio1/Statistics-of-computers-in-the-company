using System;
using WPF_46731r.ViewModels;

namespace WPF_46731r.State.Navigators
{
    public class Navigator : INavigator
    {
        private ViewModelBase _currentViewModel;
        public event Action CurrentViewModelChanged;
        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel?.Dispose();

                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
