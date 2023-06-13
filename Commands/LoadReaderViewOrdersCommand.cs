using PublishingHouse.Interfaces;
using System.Windows;
using System;
using PublishingHouse.Models.OrderEntity;
using System.Collections.Generic;
using PublishingHouse.ViewModels;

namespace PublishingHouse.Commands
{
    public class LoadReaderViewOrdersCommand : CommandBase
    {
        private readonly ReaderViewModel _readerViewModel;
        private readonly IOrderService _orderService;

        public LoadReaderViewOrdersCommand(ReaderViewModel readerViewModel, IOrderService orderService)
        {
            _readerViewModel = readerViewModel;
            _orderService = orderService;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                List<Order> orders = _orderService.GetOrdersByUserId(_readerViewModel.UserId);

                if (orders != null)
                {
                    _readerViewModel.UpdateOrders(orders);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
