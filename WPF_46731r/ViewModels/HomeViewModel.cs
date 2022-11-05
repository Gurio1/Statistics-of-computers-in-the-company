using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPF_46731r.Domain.Models;

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
