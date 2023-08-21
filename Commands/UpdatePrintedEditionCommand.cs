using PublishingHouse.DTOs;
using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class UpdatePrintedEditionCommand : AsyncCommandBase
    {
        private EditPrintedEditionViewModel _editPrintedEditionViewModel;
        private IPrintedEditionService _printedEditionService;

        public UpdatePrintedEditionCommand(
            EditPrintedEditionViewModel editPrintedEditionViewModel,
            IPrintedEditionService printedEditionService)
        {
            _printedEditionService = printedEditionService;
            _editPrintedEditionViewModel = editPrintedEditionViewModel;

            _editPrintedEditionViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(EditPrintedEditionViewModel.Author) ||
                e.PropertyName == nameof(EditPrintedEditionViewModel.Cover) ||
                e.PropertyName == nameof(EditPrintedEditionViewModel.Category) ||
                e.PropertyName == nameof(EditPrintedEditionViewModel.Description) ||
                e.PropertyName == nameof(EditPrintedEditionViewModel.Genre) ||
                e.PropertyName == nameof(EditPrintedEditionViewModel.IsAvailable) ||
                e.PropertyName == nameof(EditPrintedEditionViewModel.Price) ||
                e.PropertyName == nameof(EditPrintedEditionViewModel.ReleaseDate) ||
                e.PropertyName == nameof(EditPrintedEditionViewModel.Language) ||
                e.PropertyName == nameof(EditPrintedEditionViewModel.Title))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_editPrintedEditionViewModel.Author) &&
                !string.IsNullOrEmpty(_editPrintedEditionViewModel.Description) &&
                !string.IsNullOrEmpty(_editPrintedEditionViewModel.Genre) &&
                !string.IsNullOrEmpty(_editPrintedEditionViewModel.Language) &&
                !string.IsNullOrEmpty(_editPrintedEditionViewModel.Price) &&
                !string.IsNullOrEmpty(_editPrintedEditionViewModel.Title) &&
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                if (!Decimal.TryParse(_editPrintedEditionViewModel.Price, out decimal price))
                {
                    throw new Exception("Invalid price was written");
                }

                await _printedEditionService.UpdatePrintedEditionAsync(_editPrintedEditionViewModel.PrintedEdition);

                _editPrintedEditionViewModel.CanNavigateBack = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
