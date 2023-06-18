using PublishingHouse.Interfaces;
using System.Windows;
using System;
using System.Threading.Tasks;
using PublishingHouse.ViewModels;
using PublishingHouse.Models.UserEntity;

namespace PublishingHouse.Commands
{
    public class BlockUserCommand : AsyncCommandBase
    {
        private readonly ReaderViewModel _readerViewModel;
        private readonly IUserService _userService;

        public BlockUserCommand(ReaderViewModel readerViewModel, IUserService userService)
        {
            _readerViewModel = readerViewModel;
            _userService = userService;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                User user = await _userService.BlockUserAsync(_readerViewModel.UserId);

                _readerViewModel.User = user;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
