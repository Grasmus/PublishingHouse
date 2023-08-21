using PublishingHouse.Models.OrderEntity;
using PublishingHouse.Models.PrintedEditionEntity;
using System.Collections.Generic;
using System;
using System.Windows.Input;
using PublishingHouse.Commands;
using PublishingHouse.Interfaces;
using System.Linq;
using PublishingHouse.Constats;

namespace PublishingHouse.ViewModels
{
    public class OrderViewModel : ViewModelBase
    {
        private readonly Order _order;

        public int OrderId => _order.Id;
        public DateTime OrderDate => _order.OrderDate;
        public List<PrintedEdition> PrintedEditions => _order.PrintedEditions.ToList();
        public int PrintedEditionsAmount => _order.PrintedEditions.Count;
        public decimal TotalPrice => _order.TotalPrice;

        public string Status
        {
            get
            {
                return _order.Status;
            }

            set
            {
                _order.Status = value;

                OnPropertyChanged();
            }
        }

        public bool IsOrderPaid => Status != OrderStatus.NotPaid.ToString();

        public ICommand ViewOrderCommand { get; }
        public ICommand NavigateBackCommand { get; }
        public ICommand PayOrderCommand { get; }

        public OrderViewModel(Order order, INavigationService navigationService, IOrderService orderService)
        {
            _order = order;

            NavigateBackCommand = new NavigateBackCommand(this, navigationService);
            ViewOrderCommand = new ShowViewNavigationCommand(this, navigationService);
            PayOrderCommand = new PayOrderCommand(this, orderService);
        }

        public OrderViewModel(Order order, INavigationService navigationService)
        {
            _order = order;

            NavigateBackCommand = new NavigateBackCommand(this, navigationService);
            ViewOrderCommand = new ShowViewNavigationCommand(this, navigationService);
        }
    }
}
