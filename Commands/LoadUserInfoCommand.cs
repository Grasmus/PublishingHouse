using PublishingHouse.Constats;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.UserEntity;
using PublishingHouse.ViewModels;
using System;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class LoadUserInfoCommand : CommandBase
    {
        private readonly IUserService _userService;
        private readonly MainPageViewModel _mainPageViewModel;

        public LoadUserInfoCommand(MainPageViewModel mainPageViewModel, IUserService userService)
        {
            _userService = userService;
            _mainPageViewModel = mainPageViewModel;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                User user = _userService.GetCurrentUser();
                
                _mainPageViewModel.UserId = user.Id;
                _mainPageViewModel.FirstName = user.FirstName;
                _mainPageViewModel.LastName = user.LastName;
                _mainPageViewModel.Login = user.Login;
                _mainPageViewModel.IsUserBlacklisted = user.IsBlacklisted;
                _mainPageViewModel.IsAdmin = user.Role == UserRole.Administrator.ToString() ? true : false;
                _mainPageViewModel.IsReader = user.Role == UserRole.Reader.ToString() ? true : false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
