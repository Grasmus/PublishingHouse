using PublishingHouse.Constats;
using PublishingHouse.Helpers;
using PublishingHouse.ViewModels;
using System;
using System.Drawing;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class LoadTemplateBookCoverCommand : CommandBase
    {
        private MainPageViewModel _mainPageViewModel;

        public LoadTemplateBookCoverCommand(MainPageViewModel mainPageViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                _mainPageViewModel.Cover = Helper.ConvertImageToByteArray(Image.FromFile(PathConstants.BookCoverTemplatePath));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
