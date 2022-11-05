using System.Windows.Input;
using WPF_46731r.Commands.Navigation;
using WPF_46731r.Services;

namespace WPF_46731r.ViewModels
{
    public class NavigationViewModelBar : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateComputerCommand { get; }

        public NavigationViewModelBar(INavigationService<HomeViewModel> homeNavService,INavigationService<ComputersViewModel> compNavServ)
        {
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavService);
            NavigateComputerCommand = new NavigateCommand<ComputersViewModel>(compNavServ);
        }
    }
}
