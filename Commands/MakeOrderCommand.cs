using PublishingHouse.DTOs;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.PrintedEditionEntity;
using PublishingHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class MakeOrderCommand : AsyncCommandBase
    {
        private MainPageViewModel _mainPageViewModel;
        private IOrderService _orderService;
        private IUserService _userService;

        public MakeOrderCommand(MainPageViewModel mainPageViewModel, IOrderService orderService, IUserService userService)
        {
            _mainPageViewModel = mainPageViewModel;
            _orderService = orderService;
            _userService = userService;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                List<PrintedEdition> printedEditions = new List<PrintedEdition>();

                foreach (PrintedEditionCartInfoViewModel cartInfoViewModel in _mainPageViewModel.CartPrintedEditions)
                {
                    printedEditions.Add(cartInfoViewModel.PrintedEdition);
                }

                CreateOrderDTO createOrderDTO = new CreateOrderDTO()
                {
                    User = _userService.GetCurrentUser(),
                    OrderDate = DateTime.Now,
                    PrintedEditions = printedEditions
                };

                await _orderService.CreateOrderAsync(createOrderDTO);

                _mainPageViewModel.CartPrintedEditions.Clear();
                _mainPageViewModel.HasCartItems = false;
                _mainPageViewModel.TotalSum = 0;
                _mainPageViewModel.LoadOrdersCommand.Execute(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
