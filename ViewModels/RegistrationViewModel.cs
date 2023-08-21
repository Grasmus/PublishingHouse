using PublishingHouse.Commands;
using PublishingHouse.Interfaces;
using PublishingHouse.Services;
using System.Windows.Input;

namespace PublishingHouse.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public RegistrationViewModel(
            AuthenticationService authenticationService,
            INavigationService navigationService)
        {
            RegistrationCommand = new RegistrationCommand(this, authenticationService, navigationService);
            NavigateBackCommand = new NavigateBackCommand(this, navigationService);
        }

        private string _firstName;

        public string FirstName 
        { 
            get => _firstName;

            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;

            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
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

        public ICommand RegistrationCommand { get; }
        public ICommand NavigateBackCommand { get; }
    }
}
