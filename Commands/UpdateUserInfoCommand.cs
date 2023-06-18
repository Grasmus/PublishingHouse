using PublishingHouse.DTOs;
using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class UpdateUserInfoCommand : AsyncCommandBase
    {
        private readonly IUserService _userService;
        private readonly MainPageViewModel _mainPageViewModel;

        public UpdateUserInfoCommand(MainPageViewModel mainPageViewModel, IUserService userService)
        {
            _mainPageViewModel = mainPageViewModel;
            _userService = userService;

            _mainPageViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainPageViewModel.FirstName) ||
                e.PropertyName == nameof(MainPageViewModel.LastName) ||
                e.PropertyName == nameof(MainPageViewModel.Login))
            {
                OnCanExecuteChanged();
            }
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            UserDTO userDTO = new UserDTO()
            {
                FirstName = _mainPageViewModel.FirstName,
                LastName = _mainPageViewModel.LastName,
                Login = _mainPageViewModel.Login,
            };

            try
            {
                await _userService.UpdateUserAsync(userDTO);

                MessageBox.Show("Account details updated succesfully", "Account information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
