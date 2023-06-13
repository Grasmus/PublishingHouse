using PublishingHouse.Constats;
using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

namespace PublishingHouse.Commands
{
    public class PayOrderCommand : AsyncCommandBase
    {
        private readonly OrderViewModel _orderViewModel;
        private readonly IOrderService _orderService;

        public PayOrderCommand(OrderViewModel orderViewModel, IOrderService orderService)
        {
            _orderViewModel = orderViewModel;
            _orderService = orderService;

            _orderViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(OrderViewModel.Status))
            {
                OnCanExecuteChanged();
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return !_orderViewModel.IsOrderPaid;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _orderService.ChangeOrderStatusAsync(_orderViewModel.OrderId, OrderStatus.Paid);

                _orderViewModel.Status = OrderStatus.Paid.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
