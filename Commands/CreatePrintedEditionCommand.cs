using PublishingHouse.ViewModels;
using System.Windows;
using System;
using PublishingHouse.DTOs;
using PublishingHouse.Interfaces;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.IdentityModel.Tokens;

namespace PublishingHouse.Commands
{
    public class CreatePrintedEditionCommand : AsyncCommandBase
    {
        private MainPageViewModel _mainPageViewModel;
        private IPrintedEditionService _printedEditionService;

        public CreatePrintedEditionCommand(MainPageViewModel mainPageViewModel, IPrintedEditionService printedEditionService)
        {
            _mainPageViewModel = mainPageViewModel;
            _printedEditionService = printedEditionService;

            _mainPageViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainPageViewModel.Author) ||
                e.PropertyName == nameof(MainPageViewModel.Cover) ||
                e.PropertyName == nameof(MainPageViewModel.Category) ||
                e.PropertyName == nameof(MainPageViewModel.Description) ||
                e.PropertyName == nameof(MainPageViewModel.Genre) ||
                e.PropertyName == nameof(MainPageViewModel.IsAvailable) ||
                e.PropertyName == nameof(MainPageViewModel.Language) ||
                e.PropertyName == nameof(MainPageViewModel.Price) ||
                e.PropertyName == nameof(MainPageViewModel.ReleaseDate) ||
                e.PropertyName == nameof(MainPageViewModel.Title))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_mainPageViewModel.Author) &&
                !string.IsNullOrEmpty(_mainPageViewModel.Description) &&
                !string.IsNullOrEmpty(_mainPageViewModel.Genre) &&
                !string.IsNullOrEmpty(_mainPageViewModel.Language) &&
                !string.IsNullOrEmpty(_mainPageViewModel.Price) &&
                !string.IsNullOrEmpty(_mainPageViewModel.Title) &&
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                decimal price;

                if(!Decimal.TryParse(_mainPageViewModel.Price, out price))
                {
                    throw new Exception("Invalid price was written");
                }

                CreatePrintedEditionDTO createPrintedEditionDTO = new CreatePrintedEditionDTO()
                {
                    Author = _mainPageViewModel.Author,
                    Title = _mainPageViewModel.Title,
                    Description = _mainPageViewModel.Description,
                    Genre = _mainPageViewModel.Genre,
                    Cover = _mainPageViewModel.Cover,
                    Language = _mainPageViewModel.Language,
                    ReleaseDate = _mainPageViewModel.ReleaseDate,
                    IsAvailable = _mainPageViewModel.IsAvailable,
                    Category = _mainPageViewModel.Category,
                    Price = price
                };

                await _printedEditionService.CreatePrintedEditionAsync(createPrintedEditionDTO);

                _mainPageViewModel.LoadBooksCommand.Execute(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
