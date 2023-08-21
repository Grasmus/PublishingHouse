using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace PublishingHouse.Helpers
{
    public static class Helper
    {
        public static async void FireAndForget(this Task task)
        {
            try
            {
                await task;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public static byte[]? ConvertImageToByteArray(System.Drawing.Image? image)
        {
            if (image is null)
            {
                return null;
            }

            MemoryStream memmoryStream = new MemoryStream();

            image.Save(memmoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            return memmoryStream.ToArray();
        }
    }
}
