using PublishingHouse.Interfaces;
using PublishingHouse.Models.UserEntity;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class LoadReadersCommand : CommandBase
    {
        public delegate void UpdateReaders(List<User> readers);

        private UpdateReaders _updateReaders;
        private readonly IUserService _userService;

        public LoadReadersCommand(UpdateReaders updateReaders, IUserService userService)
        {
            _updateReaders = updateReaders;
            _userService = userService;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                List<User> readers = _userService.GetReaders();

                if(readers != null)
                {
                    _updateReaders(readers);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
