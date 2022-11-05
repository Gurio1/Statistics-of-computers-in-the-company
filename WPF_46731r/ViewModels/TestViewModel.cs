using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_46731r.ViewModels
{
    public class TestViewModel : ViewModelBase
    {
        private readonly NavigationViewModelBar _navigationViewModelBar;

        public TestViewModel(NavigationViewModelBar navigationViewModelBar)
        {
            _navigationViewModelBar = navigationViewModelBar;
        }
    }
}
