using System.Collections.ObjectModel;
using System.Drawing;

namespace WPF_46731r.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private NavigationViewModelBar NavigationBar { get; }


        public HomeViewModel(NavigationViewModelBar navigationViewModelBar)
        {
            NavigationBar = navigationViewModelBar;
        }
    }
    
}
