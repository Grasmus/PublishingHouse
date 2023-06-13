using PublishingHouse.DTOs;
using PublishingHouse.Interfaces;
using PublishingHouse.Services;
using PublishingHouse.ViewModels;
using System.Threading.Tasks;
using System.Windows;
using System;
using PublishingHouse.Helpers;
using System.ComponentModel;
using System.Windows.Navigation;

namespace PublishingHouse.Commands
{
    public class RegistrationCommand : AsyncCommandBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;
        private readonly RegistrationViewModel _registrationModel;

        public RegistrationCommand(RegistrationViewModel registrationModel, 
            IAuthenticationService authenticationService,
            INavigationService navigationService)
        {
            _registrationModel = registrationModel;
            _authenticationService = authenticationService;
            _navigationService = navigationService;

            _registrationModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(RegistrationViewModel.Login) ||
                e.PropertyName == nameof(RegistrationViewModel.Password) ||
                e.PropertyName == nameof(RegistrationViewModel.FirstName) ||
                e.PropertyName == nameof(RegistrationViewModel.LastName))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_registrationModel.Login) &&
                !string.IsNullOrEmpty(_registrationModel.Password) &&
                !string.IsNullOrEmpty(_registrationModel.FirstName) &&
                !string.IsNullOrEmpty(_registrationModel.LastName) &&
                base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            UserRegisterDTO userDTO = new UserRegisterDTO()
            {
                FirstName = _registrationModel.FirstName,
                LastName = _registrationModel.LastName,
                Login = _registrationModel.Login,
                Password = _registrationModel.Password
            };

            try
            {
                await _authenticationService.RegistrationAsync(userDTO);
                _navigationService.Navigate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
