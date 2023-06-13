using PublishingHouse.Interfaces;

namespace PublishingHouse.Commands
{
    public class NavigateBackCommand : CommandBase
    {
        private INavigationService _navigationService;

        public NavigateBackCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.GoBack();
        }
    }
}
