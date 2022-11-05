using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_46731r.ViewModels
{
    public class ComputersViewModel : ViewModelBase
    {
        private NavigationViewModelBar NavigationBar { get; }

        public ComputersViewModel(NavigationViewModelBar navigationViewModelBar)
        {
            NavigationBar = navigationViewModelBar;
        }
    }
}
