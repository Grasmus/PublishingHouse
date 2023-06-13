using PublishingHouse.Commands;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.PrintedEditionEntity;
using System;
using System.Windows;
using System.Windows.Input;

namespace PublishingHouse.ViewModels
{
    public class PrintedEditionViewModel : ViewModelBase
    {
        private readonly PrintedEdition _printedEdition;
        private readonly MainPageViewModel _mainPageViewModel;

        public string Title => _printedEdition.Title;
        public string? Description => _printedEdition.Description;
        public string Language => _printedEdition.Language;
        public decimal Price => _printedEdition.Price;
        public DateTime ReleaseDate => _printedEdition.ReleaseDate;
        public DateTime Updated => _printedEdition.Updated;
        public bool? IsAvailable => _printedEdition.IsAvailable;
        public string Author => _printedEdition.Author;
        public string Genre => _printedEdition.Genre;
        public byte[]? Cover => _printedEdition.Cover;

        public ICommand ViewBookCommand { get; }
        public ICommand NavigateBackCommand { get; }
        public ICommand AddBookToOrderCommand { get; }

        public Visibility AddBookButtonVisibility
        {
            get
            {
                return _mainPageViewModel.IsUserBlacklisted ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public PrintedEditionViewModel(
            MainPageViewModel mainPageViewModel, 
            PrintedEdition printedEdition, 
            INavigationService navigationService)
        {
            _printedEdition = printedEdition;
            _mainPageViewModel = mainPageViewModel;

            ViewBookCommand = new ShowViewNavigationCommand(this, navigationService);
            NavigateBackCommand = new NavigateBackCommand(navigationService);
            AddBookToOrderCommand = new AddBookToOrderCommand(mainPageViewModel, printedEdition);
        }
    }
}
