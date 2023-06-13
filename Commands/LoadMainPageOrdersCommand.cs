using PublishingHouse.Interfaces;
using System.Windows;
using System;
using PublishingHouse.Models.OrderEntity;
using System.Collections.Generic;
using PublishingHouse.ViewModels;

namespace PublishingHouse.Commands
{
    public class LoadMainPageOrdersCommand : CommandBase
    {
        private readonly MainPageViewModel _mainPageViewModel;
        private readonly IOrderService _orderService;

        public LoadMainPageOrdersCommand(MainPageViewModel mainPageViewModel, IOrderService orderService)
        {
            _mainPageViewModel = mainPageViewModel;
            _orderService = orderService;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                List<Order> orders = _orderService.GetOrdersByUserId(_mainPageViewModel.UserId);

                if(orders != null)
                {
                    _mainPageViewModel.UpdateOrders(orders);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
