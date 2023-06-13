using PublishingHouse.ViewModels;
using System.Linq;

namespace PublishingHouse.Commands
{
    public class RemoveBookFromOrderCommand : CommandBase
    {
        private MainPageViewModel _mainPageViewModel;
        private PrintedEditionCartInfoViewModel _cartInfoViewModel;

        public RemoveBookFromOrderCommand(
            MainPageViewModel mainPageViewModel,
            PrintedEditionCartInfoViewModel cartInfoViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
            _cartInfoViewModel = cartInfoViewModel;
        }

        public override void Execute(object? parameter)
        {
            _mainPageViewModel.CartPrintedEditions.Remove(_cartInfoViewModel);
            _mainPageViewModel.HasCartItems = _mainPageViewModel.CartPrintedEditions.Any();
            _mainPageViewModel.TotalSum -= _cartInfoViewModel.Price;
        }
    }
}
