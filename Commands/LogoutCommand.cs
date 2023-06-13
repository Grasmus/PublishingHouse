using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;
using System.Threading;

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
            Thread.CurrentPrincipal = null;
            _navigationService.Navigate(_loginViewModel);
        }
    }
}
