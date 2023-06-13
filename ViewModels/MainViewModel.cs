using PublishingHouse.Stores;
using System;

namespace PublishingHouse.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;

        public ViewModelBase CurrentViewModel => _navigationStore.CurrentView;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore; 
            
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
             OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
