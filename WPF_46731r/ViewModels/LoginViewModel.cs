using System;
using System.Windows.Input;
using WPF_46731r.Commands.Authentication;
using WPF_46731r.Domain.Service.Abstractions;
using WPF_46731r.State.Navigators;

namespace WPF_46731r.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName;
        private string _password;
        private string _errorMessageEmail;
        private string _errorMessagePassword;

        public string UserName { get => _userName; set { _userName = value; OnPropretyChanged(nameof(UserName)); } }
        public string Password { get => _password; set { _password = value; OnPropretyChanged(nameof(Password)); } }
        public string ErrorMessageEmail { get => _errorMessageEmail; set { _errorMessageEmail = value; OnPropretyChanged(nameof(ErrorMessageEmail)); } }
        public string ErrorMessagePassword { get => _errorMessagePassword; set { _errorMessagePassword = value; OnPropretyChanged(nameof(ErrorMessagePassword)); } }

        public ICommand LoginCommand { get; }

        public LoginViewModel(WindowNavigator windowNavigator,IApiClient apiClient)
        {
            LoginCommand = new LoginCommand(this, windowNavigator, apiClient);
        }

 
    }
}
