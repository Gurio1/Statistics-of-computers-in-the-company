using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.State.Navigators;
using WPF_46731r.ViewModels;

namespace WPF_46731r.Commands.Authentication
{
    public class LoginCommand : CommandBase
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly WindowNavigator _winNav;
        private readonly IApiClient _apiClient;

        public LoginCommand(LoginViewModel loginViewModel,WindowNavigator winNav,IApiClient apiClient)
        {
            _loginViewModel = loginViewModel;
            _winNav = winNav;
            _apiClient = apiClient;
        }

        public override async void Execute(object? parameter)
        {
            var serverResponse = await _apiClient.LogIn(_loginViewModel.UserName, _loginViewModel.Password);

            if (serverResponse.IsSuccessStatusCode)
            {
                App.InitMainView(serverResponse.User);
                return;
            }

            _loginViewModel.ErrorMessageEmail = serverResponse.Errors?.EmailErrorsToString();

            if (serverResponse.StatusCode == 500)
            {
                _loginViewModel.ErrorMessageEmail = "Server error.Please contact administrator";
            }

            _loginViewModel.ErrorMessagePassword = serverResponse.Errors?.PasswordErrorsToString();
        }
    }
}
