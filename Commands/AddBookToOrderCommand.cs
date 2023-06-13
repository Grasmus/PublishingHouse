using PublishingHouse.Models.PrintedEditionEntity;
using PublishingHouse.ViewModels;
using System;
using System.ComponentModel;

namespace PublishingHouse.Commands
{
    public class AddBookToOrderCommand : CommandBase
    {
        private MainPageViewModel _mainPageViewModel;
        private PrintedEdition _printedEdition;
        private PrintedEditionCartInfoViewModel _cartInfoViewModel;

        public AddBookToOrderCommand(
            MainPageViewModel mainPageViewModel, 
            PrintedEdition printedEdition)
        {
            _mainPageViewModel = mainPageViewModel;
            _printedEdition = printedEdition;
            _cartInfoViewModel = new PrintedEditionCartInfoViewModel(_mainPageViewModel, _printedEdition);

            _mainPageViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainPageViewModel.HasCartItems))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            foreach (var CartPrintedEdition in _mainPageViewModel.CartPrintedEditions)
            {
                if (CartPrintedEdition.PrintedEdition == _printedEdition || _mainPageViewModel.IsUserBlacklisted)
                {
                    return false;
                }
            }

            return true;
        }

        public override void Execute(object? parameter)
        {
            _mainPageViewModel.CartPrintedEditions.Add(_cartInfoViewModel);
            _mainPageViewModel.HasCartItems = true;
            _mainPageViewModel.TotalSum += _cartInfoViewModel.Price;
        }
    }
}
