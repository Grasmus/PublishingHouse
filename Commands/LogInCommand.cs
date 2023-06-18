using PublishingHouse.DTOs;
using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class LogInCommand : CommandBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;
        private readonly LoginViewModel _loginModel;

        public LogInCommand(LoginViewModel loginModel, 
            IAuthenticationService authenticationService,
            INavigationService navigationService)
        {
            _loginModel = loginModel;
            _authenticationService = authenticationService;
            _navigationService = navigationService;

            _loginModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(LoginViewModel.Login) ||
                e.PropertyName == nameof(LoginViewModel.Password)) 
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_loginModel.Login) && 
                !string.IsNullOrEmpty(_loginModel.Password) && 
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            UserLoginDTO userDTO = new UserLoginDTO()
            {
                Login = _loginModel.Login,
                Password = _loginModel.Password
            };

            try
            {
                _authenticationService.LogIn(userDTO);
                _navigationService.Navigate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
