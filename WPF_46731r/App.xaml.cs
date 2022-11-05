using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WPF_46731r.Domain.Models;
using WPF_46731r.Services;
using WPF_46731r.State.Navigators;
using WPF_46731r.ViewModels;
using WPF_46731r.Views;

namespace WPF_46731r
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application  
    {
        private static WindowNavigator _winNav;
        private  static INavigator _navigator;
        private static NavigationViewModelBar _navBar;

        public App()
        {
            _winNav = new WindowNavigator();
            _navigator = new Navigator();
            _navBar = new NavigationViewModelBar(CreateHomeViewModel(), CreateComputersViewModel());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var navServ = CreateHomeViewModel();
            navServ.Navigate();

            //var loginView = new LoginView()
            //{
            //    DataContext = new LoginViewModel(_winNav)
            //};
            //_winNav.CurrentView = loginView;

            InitMainView(new ApplicationUser() { Name = "Test" });
            base.OnStartup(e);
        }

        public static void InitMainView(ApplicationUser user)
        {
            _winNav.CurrentView = new MainWindow()
            {
                DataContext = new MainViewModel(_navigator,user,_navBar)
            };
        }


        private INavigationService<HomeViewModel> CreateHomeViewModel()
        {
            return new NavigationService<HomeViewModel>(_navigator, () => new HomeViewModel(_navBar));
        }

        private INavigationService<ComputersViewModel> CreateComputersViewModel()
        {
            return new NavigationService<ComputersViewModel>(_navigator, () => new ComputersViewModel(_navBar));
        }
    }
}
