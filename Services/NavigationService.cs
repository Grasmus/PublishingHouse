using PublishingHouse.Interfaces;
using PublishingHouse.Stores;
using PublishingHouse.ViewModels;
using System;

namespace PublishingHouse.Services
{
    public class NavigationService<TViewModel> : INavigationService where TViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createModelNavigate)
        {
            _navigationStore = navigationStore;
            _createViewModel = createModelNavigate;
        }

        public NavigationService(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public void Navigate() 
        {
            _navigationStore.CurrentView = _createViewModel();
        }

        public void Navigate(ViewModelBase viewModel)
        {
            _navigationStore.CurrentView = viewModel;
        }

        public void GoBack()
        {
            _navigationStore.GoBack();
        }
    }
}
