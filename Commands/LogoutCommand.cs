using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class LogoutCommand : CommandBase
    {
        private readonly INavigationService _navigationService;
        private readonly LoginViewModel _loginViewModel;

        public LogoutCommand(LoginViewModel loginViewModel, INavigationService navigationService)
        {
            _loginViewModel = loginViewModel;
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            Application.Current.Resources.Remove("UserLogin");
            Application.Current.Resources.Remove("UserRole");

            _navigationService.Navigate(_loginViewModel);
        }
    }
}
