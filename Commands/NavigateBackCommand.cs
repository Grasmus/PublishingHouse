using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;

namespace PublishingHouse.Commands
{
    public class NavigateBackCommand : CommandBase
    {
        private ViewModelBase _viewModel;
        private INavigationService _navigationService;

        public NavigateBackCommand(
            ViewModelBase viewModel, 
            INavigationService navigationService)
        {
            _viewModel = viewModel;
            _navigationService = navigationService;
        }

        public override bool CanExecute(object? parameter)
        {
            return _viewModel.CanNavigateBack;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.GoBack();
        }
    }
}
