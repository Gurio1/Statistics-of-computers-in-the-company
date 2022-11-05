using System.Threading.Tasks;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Service;
using WPF_46731r.State.Navigators;
using WPF_46731r.ViewModels;

namespace WPF_46731r.Commands.Authentication
{
    public class LoginCommand : AsyncCommandBse
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly WindowNavigator _winNav;

        public LoginCommand(LoginViewModel loginViewModel,WindowNavigator winNav)
        {
            _loginViewModel = loginViewModel;
            _winNav = winNav;
        }
        public override async Task ExecuteAsync(object? parameter)
        {
            var serverResponse = await HttpService.LogIn(_loginViewModel.UserName, _loginViewModel.Password);

            if (serverResponse.IsSuccessStatusCode)
            {
                App.InitMainView(serverResponse.User);
            }

            _loginViewModel.ErrorMessageEmail = serverResponse.Errors?.EmailErrorsToString();

            if (serverResponse.StatusCode == 500)
            {
                _loginViewModel.ErrorMessageEmail = "Server error.Please connect administrator";
            }

            _loginViewModel.ErrorMessagePassword = serverResponse.Errors?.PasswordErrorsToString();
        }
    }
}
