using System.Windows.Input;
using WPF_46731r.Commands;
using WPF_46731r.Commands.Navigation;
using WPF_46731r.Domain.Models;
using WPF_46731r.Services;
using WPF_46731r.State.Navigators;

namespace WPF_46731r.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;

        public ApplicationUser User { get; }
        public ICommand NavigateHomeCommand { get; }
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public NavigationViewModelBar NavBar { get; }

        public MainViewModel(INavigator navigator,ApplicationUser user,NavigationViewModelBar viewModelBar)
        {
            _navigator = navigator;

            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;

            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(new NavigationService<HomeViewModel>(_navigator,()=>new HomeViewModel(viewModelBar)));

            User = user;

            NavBar = viewModelBar;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropretyChanged(nameof(CurrentViewModel));
        }
    }
}
