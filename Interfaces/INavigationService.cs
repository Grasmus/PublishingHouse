using PublishingHouse.ViewModels;

namespace PublishingHouse.Interfaces
{
    public interface INavigationService
    {
        void Navigate(ViewModelBase viewModel);
        void Navigate();
        void GoBack();
    }
}
