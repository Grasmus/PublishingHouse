using Microsoft.IdentityModel.Tokens;
using PublishingHouse.Commands;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.CategoryEntity;
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
        private readonly EditPrintedEditionViewModel _editPrintedEditionViewModel;

        public string Title
        {
            get => _printedEdition.Title;
            set => _printedEdition.Title = value;
        }

        public string? Description
        {
            get => _printedEdition.Description;
            set => _printedEdition.Description = value;
        }

        public string Language
        {
            get => _printedEdition.Language;
            set => _printedEdition.Language = value;
        }

        public decimal Price
        {
            get => _printedEdition.Price;
            set => _printedEdition.Price = value;
        }

        public DateTime ReleaseDate
        {
            get => _printedEdition.ReleaseDate;
            set => _printedEdition.ReleaseDate = value;
        }

        public bool IsAvailable
        {
            get => _printedEdition.IsAvailable;
            set => _printedEdition.IsAvailable = value;
        }

        public string Author
        {
            get => _printedEdition.Author;
            set => _printedEdition.Author = value;
        }

        public string Genre
        {
            get => _printedEdition.Genre;
            set => _printedEdition.Genre = value;
        }

        public byte[]? Cover
        {
            get => _printedEdition.Cover;
            set => _printedEdition.Cover = value;
        }

        public Category? Category
        {
            get => _printedEdition.Category;
            set => _printedEdition.Category = value;
        }

        public ICommand ViewBookCommand { get; }
        public ICommand NavigateBackCommand { get; }
        public ICommand AddBookToOrderCommand { get; }
        public ICommand EditModeCommand { get; }
        public ICommand LoadImageCommand { get; }

        public Visibility AddBookButtonVisibility
        {
            get
            {
                return _mainPageViewModel.IsUserBlacklisted || _mainPageViewModel.IsAdmin ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public Visibility EditButtonVisibility
        {
            get
            {
                return _mainPageViewModel.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility IsNotAvailableVisibility
        {
            get
            {
                return IsAvailable ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        public PrintedEditionViewModel(
            MainPageViewModel mainPageViewModel, 
            PrintedEdition printedEdition, 
            INavigationService navigationService,
            ICategoryService categoryService,
            IPrintedEditionService printedEditionService)
        {
            _printedEdition = printedEdition;
            _mainPageViewModel = mainPageViewModel;
            _editPrintedEditionViewModel = new EditPrintedEditionViewModel(
                printedEdition, 
                categoryService, 
                navigationService, 
                printedEditionService);

            ViewBookCommand = new ShowViewNavigationCommand(this, navigationService);
            NavigateBackCommand = new NavigateBackCommand(this, navigationService);
            AddBookToOrderCommand = new AddBookToOrderCommand(mainPageViewModel, printedEdition);
            EditModeCommand = new ShowViewNavigationCommand(_editPrintedEditionViewModel, navigationService);
            LoadImageCommand = new LoadImageCommand(UpdateCover);
        }

        public void UpdateCover(byte[]? cover)
        {
            Cover = cover;
        }
    }
}
