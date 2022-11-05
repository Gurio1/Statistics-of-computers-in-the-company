using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_46731r.State.Navigators;
using WPF_46731r.ViewModels;

namespace WPF_46731r.Services
{
    public class NavigationService<TViewModel> : INavigationService<TViewModel>
        where TViewModel : ViewModelBase
    {
        private readonly INavigator _navigator;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(INavigator navigator, Func<TViewModel> createViewModel)
        {
            _navigator = navigator;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigator.CurrentViewModel = _createViewModel();
        }
    }
}
