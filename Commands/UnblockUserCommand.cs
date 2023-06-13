using PublishingHouse.Interfaces;
using System.Windows;
using System;
using System.Threading.Tasks;
using PublishingHouse.ViewModels;
using PublishingHouse.Models.UserEntity;

namespace PublishingHouse.Commands
{
    public class UnblockUserCommand : AsyncCommandBase
    {
        private readonly ReaderViewModel _readerViewModel;
        private readonly IUserService _userService;

        public UnblockUserCommand(ReaderViewModel readerViewModel, IUserService userService)
        {
            _userService = userService;
            _readerViewModel = readerViewModel;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                User user = await _userService.UnblockUserAsync(_readerViewModel.UserId);

                _readerViewModel.User = user;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
