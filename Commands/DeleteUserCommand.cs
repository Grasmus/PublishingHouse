using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class DeleteUserCommand : AsyncCommandBase
    {
        private readonly MainPageViewModel _mainPageViewModel;
        private readonly IUserService _userService;

        public DeleteUserCommand(MainPageViewModel mainPageViewModel,
            IUserService userService)
        {
            _mainPageViewModel = mainPageViewModel;
            _userService = userService;
        }

        public override async Task ExecuteAsync(object? parameter) 
        {
            try
            {
                await _userService.DeleteCurrentUserAsync();
                _mainPageViewModel.LogoutCommand.Execute(parameter);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
