using PublishingHouse.ViewModels;
using System.Windows;
using System;
using Microsoft.Win32;
using PublishingHouse.Helpers;
using System.Drawing;

namespace PublishingHouse.Commands
{
    public class LoadImageCommand : CommandBase
    {
        private readonly MainPageViewModel _mainPageViewModel;

        public LoadImageCommand(MainPageViewModel mainPageViewModel)
        {
            _mainPageViewModel = mainPageViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == true)
                {
                    _mainPageViewModel.Cover = Helper.ConvertImageToByteArray(Image.FromFile(openFileDialog.FileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
