using PublishingHouse.Interfaces;

namespace PublishingHouse.Commands
{
    public class NavigationCommand : CommandBase
    {
        private INavigationService _navigationService;

        public NavigationCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}
