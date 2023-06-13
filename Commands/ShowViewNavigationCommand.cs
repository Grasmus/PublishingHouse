using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;

namespace PublishingHouse.Commands
{
    public class ShowViewNavigationCommand : CommandBase
    {
        private INavigationService _navigationService;
        private ViewModelBase _viewModel;

        public ShowViewNavigationCommand(ViewModelBase viewModel, INavigationService navigationService)
        {
            _navigationService = navigationService;
            _viewModel = viewModel;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_viewModel);
        }
    }
}
