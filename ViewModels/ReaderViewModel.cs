using PublishingHouse.Commands;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.OrderEntity;
using PublishingHouse.Models.UserEntity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PublishingHouse.ViewModels
{
    public class ReaderViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private User _user;

        public User User 
        { 
            get { return _user; } 
            
            set 
            { 
                _user = value;

                OnPropertyChanged();
            }
        }

        public int UserId => _user.Id;
        public string FirstName => _user.FirstName;
        public string LastName => _user.LastName;
        public bool IsBlacklisted => _user.IsBlacklisted;
        public DateTime CreateDate => _user.CreatedDate;

        public Visibility UnblockButtonVisibility
        {
            get
            {
                return IsBlacklisted ? Visibility.Visible : Visibility.Collapsed;
            }
        }

        public Visibility BlockButtonVisibility
        {
            get
            {
                return IsBlacklisted ? Visibility.Collapsed : Visibility.Visible;
            }
        }

        private ObservableCollection<OrderViewModel> _orders;

        public ObservableCollection<OrderViewModel> Orders
        {
            get
            {
                if(_orders == null)
                {
                    _orders = new ObservableCollection<OrderViewModel>();
                }

                return _orders;
            }

            set
            {
                _orders = value;
            }
        }

        public ICommand ViewOrdersCommand { get; }
        public ICommand NavigateBackCommand { get; }
        public ICommand LoadOrdersCommand { get; }
        public ICommand BlockUserCommand { get; }
        public ICommand UnblockUserCommand { get; }

        public ReaderViewModel(User user,
            IOrderService orderService,
            INavigationService navigationService,
            IUserService userService)
        {
            _user = user;
            _navigationService = navigationService;

            ViewOrdersCommand = new ShowViewNavigationCommand(this, navigationService);
            NavigateBackCommand = new NavigateBackCommand(navigationService);
            LoadOrdersCommand = new LoadReaderViewOrdersCommand(this, orderService);
            BlockUserCommand = new BlockUserCommand(this, userService);
            UnblockUserCommand = new UnblockUserCommand(this, userService);

            PropertyChanged += OnBlacklistedChanged;
        }

        private void OnBlacklistedChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(User))
            {
                OnPropertyChanged(nameof(IsBlacklisted));
                OnPropertyChanged(nameof(BlockButtonVisibility));
                OnPropertyChanged(nameof(UnblockButtonVisibility));
            }
        }

        public static ReaderViewModel LoadReaderViewModel(User user,
            IOrderService orderService,
            INavigationService navigationService, 
            IUserService userService)
        {
            var viewModel = new ReaderViewModel(user, orderService, navigationService, userService);

            viewModel.LoadOrdersCommand.Execute(null);

            return viewModel;
        }

        public void UpdateOrders(List<Order> orders)
        {
            Orders.Clear();

            foreach (var order in orders) 
            {
                Orders.Add(new OrderViewModel(order, _navigationService));
            }
        }
    }
}
