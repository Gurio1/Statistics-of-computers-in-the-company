using System;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using Microsoft.Extensions.Hosting;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Service;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.Services;
using WPF_46731r.State.Navigators;
using WPF_46731r.ViewModels;
using WPF_46731r.ViewModels.ComputersView;
using WPF_46731r.Views;

namespace WPF_46731r
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application  
    {
        private static NavigationViewModelBar _navBar;
        private static ApplicationUser _user;

        private static IHost _builder;

        public App()
        {
            _builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    ConfigureServices(services);
                })
                .Build();
            _navBar = _builder.Services.GetRequiredService<NavigationViewModelBar>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var loginView = _builder.Services.GetRequiredService<LoginView>();
            var winNav = _builder.Services.GetRequiredService<WindowNavigator>();
            winNav.CurrentView = loginView;

            base.OnStartup(e);
            
        }

        public static async void InitMainView(ApplicationUser user)
        {
            var apiClient = _builder.Services.GetRequiredService<IApiClient>();
            _user = user;
            var entities  = await apiClient.GetAllBuildings(user);
            var winNav = _builder.Services.GetRequiredService<WindowNavigator>();
            var compViewModel = _builder.Services.GetRequiredService<ComputersViewModel>();
            compViewModel.BindDataToTheTree(entities);
            winNav.CurrentView = new MainWindow()
            {
                DataContext = new MainViewModel(_builder.Services.GetRequiredService<INavigator>(),user,_navBar)
            };
        }
        
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<WindowNavigator>();

            services.AddTransient<HomeViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddScoped<ComputersViewModel>();

            services.AddHttpClient<IApiClient,ApiClient>(client =>
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + _user?.JWT);
            });
            services.AddSingleton<INavigator, Navigator>();
            services.AddSingleton<INavigationService<HomeViewModel>, NavigationService<HomeViewModel>>();
            services.AddSingleton<INavigationService<ComputersViewModel>, NavigationService<ComputersViewModel>>();
            services.AddSingleton<NavigationViewModelBar>();
            services.AddSingleton<Func<HomeViewModel>>(provider => provider.GetRequiredService<HomeViewModel>);
            services.AddSingleton<Func<ComputersViewModel>>(provider => provider.GetRequiredService<ComputersViewModel>);

            services.AddScoped<ApplicationUser>();
            services.AddScoped<LoginView>();
            
        }
    }
}
