using PublishingHouse.Commands;
using PublishingHouse.Interfaces;
using PublishingHouse.Services;
using System.Windows.Input;

namespace PublishingHouse.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(
            AuthenticationService authenticationService,
            INavigationService regNavigationService,
            INavigationService mainPageNavigationService)
        {
            LogInCommand = new LogInCommand(this, authenticationService, mainPageNavigationService);
            NavigateToRegViewCommand = new NavigationCommand(regNavigationService);
        }

        private string _login;

        public string Login
        {
            get => _login;
            set 
            { 
                _login = value;

                OnPropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                _password = value;

                OnPropertyChanged();
            }
        }

        public ICommand LogInCommand { get; }
        public ICommand NavigateToRegViewCommand { get; } 
    }
}
