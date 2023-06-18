using PublishingHouse.Interfaces;
using PublishingHouse.Models.PrintedEditionEntity;
using PublishingHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class LoadBooksCommand : CommandBase
    {
        private readonly IPrintedEditionService _bookService;
        private readonly MainPageViewModel _mainPageViewModel;

        public LoadBooksCommand(MainPageViewModel viewModel, IPrintedEditionService bookService)
        {
            _mainPageViewModel = viewModel;
            _bookService = bookService;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                IEnumerable<PrintedEdition> printedEditions;

                if (_mainPageViewModel.IsAdmin)
                {
                    printedEditions = _bookService.LoadPrintedEditions();
                }
                else
                {
                    printedEditions = _bookService.LoadAvailablePrintedEditions();
                }

                _mainPageViewModel.UpdatePrintedEditions(printedEditions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
