using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PublishingHouse.Commands
{
    public class DeleteUserCommand : AsyncCommandBase
    {
        private readonly MainPageViewModel _mainPageViewModel;
        private readonly IUserService _userService;
        private readonly ICommand _logoutCommand;

        public DeleteUserCommand(MainPageViewModel mainPageViewModel,
            IUserService userService,
            ICommand logoutCommand)
        {
            _mainPageViewModel = mainPageViewModel;
            _userService = userService;
            _logoutCommand = logoutCommand;
        }

        public override async Task ExecuteAsync(object? parameter) 
        {
            try
            {
                await _userService.DeleteCurrentUserAsync();
                _logoutCommand.Execute(parameter);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
