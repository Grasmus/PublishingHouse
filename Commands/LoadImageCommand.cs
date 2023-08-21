using System.Windows;
using System;
using Microsoft.Win32;
using PublishingHouse.Helpers;
using System.Drawing;

namespace PublishingHouse.Commands
{
    public class LoadImageCommand : CommandBase
    {
        public delegate void UpdateCoverDelegate(byte[]? cover);
        private readonly UpdateCoverDelegate _updateCoverDelegate;

        public LoadImageCommand(UpdateCoverDelegate updateCoverDelegate)
        {
            _updateCoverDelegate = updateCoverDelegate;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == true)
                {
                    _updateCoverDelegate(Helper.ConvertImageToByteArray(Image.FromFile(openFileDialog.FileName)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
