using PublishingHouse.Commands;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.OrderEntity;
using PublishingHouse.Models.PrintedEditionEntity;
using PublishingHouse.Models.UserEntity;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PublishingHouse.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        private ObservableCollection<PrintedEditionViewModel> _printedEditions;

        public ObservableCollection<PrintedEditionViewModel> PrintedEditions
        {
            get
            {
                if(_printedEditions == null)
                {
                    _printedEditions = new ObservableCollection<PrintedEditionViewModel>();
                }

                return _printedEditions;
            }

            set
            {
                _printedEditions = value;
            }
        }

        public bool IsAdmin { get; set; }
        public bool IsReader { get; set; }

        public bool HasPrintedEditions => _printedEditions.Any();

        private ObservableCollection<PrintedEditionCartInfoViewModel> _cartPrintedEditions;

        public ObservableCollection<PrintedEditionCartInfoViewModel> CartPrintedEditions
        {
            get 
            { 
                if(_cartPrintedEditions is null) 
                {
                    _cartPrintedEditions = new ObservableCollection<PrintedEditionCartInfoViewModel>();
                }

                return _cartPrintedEditions;
            }
        }

        private ObservableCollection<OrderViewModel> _orderViewModels;

        public ObservableCollection<OrderViewModel> OrderViewModels
        {
            get
            {
                if(_orderViewModels == null)
                {
                    _orderViewModels = new ObservableCollection<OrderViewModel>();
                }

                return _orderViewModels;
            }

            set
            {
                _orderViewModels = value;
            }
        }

        private ObservableCollection<ReaderViewModel> _readerViewModels;

        public ObservableCollection<ReaderViewModel> ReaderViewModels
        {
            get
            {
                if(_readerViewModels == null)
                {
                    _readerViewModels = new ObservableCollection<ReaderViewModel>();
                }

                return _readerViewModels;
            }

            set
            {
                _readerViewModels = value;
            }
        }

        private bool _hasCartItems;

        public bool HasCartItems
        {
            get
            {
                return _hasCartItems;
            }

            set
            {
                _hasCartItems = value;

                OnPropertyChanged();
            }
        }

        private int _userId;

        public int UserId
        {
            get { return _userId; }

            set
            {
                _userId = value;

                OnPropertyChanged();
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }

            set
            {
                _firstName = value;

                OnPropertyChanged();
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }

            set
            {
                _lastName = value;

                OnPropertyChanged();
            }
        }

        private string _login;

        public string Login
        {
            get { return _login; }

            set
            {
                _login = value;

                OnPropertyChanged();
            }
        }

        private bool _isUserBlacklisted;

        public bool IsUserBlacklisted
        {
            get { return _isUserBlacklisted; }

            set
            {
                _isUserBlacklisted = value;

                OnPropertyChanged();
            }
        }

        private decimal _totalSum;

        public decimal TotalSum
        {
            get { return _totalSum; }

            set
            {
                _totalSum = value;

                OnPropertyChanged();
            }
        }

        ICommand LoadBooksCommand { get; }
        ICommand LoadUserInfoCommand { get; }
        ICommand LoadReadersCommand { get; }
        public ICommand LoadOrdersCommand {  get; }
        public ICommand UpdateUserInfoCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand MakeOrderCommand { get; }

        public MainPageViewModel(
            LoginViewModel loginViewModel, 
            INavigationService navigationService, 
            IPrintedEditionService bookService,
            IOrderService orderService,
            IUserService userService)
        {
            _navigationService = navigationService;
            _orderService = orderService;
            _userService = userService;

            LoadBooksCommand = new LoadBooksCommand(this, bookService);
            LoadUserInfoCommand = new LoadUserInfoCommand(this, userService);
            LoadOrdersCommand = new LoadMainPageOrdersCommand(this, orderService);
            LoadReadersCommand = new LoadReadersCommand(UpdateReades, userService);
            UpdateUserInfoCommand = new UpdateUserInfoCommand(this, userService);
            LogoutCommand = new LogoutCommand(loginViewModel, navigationService);
            DeleteUserCommand = new DeleteUserCommand(this, userService, LogoutCommand);
            MakeOrderCommand = new MakeOrderCommand(this, orderService, userService);
        }

        public static MainPageViewModel LoadViewModel(
            LoginViewModel loginViewModel,
            INavigationService navigationService, 
            IPrintedEditionService bookService,
            IOrderService orderService,
            IUserService userService)
        {
            var viewModel = new MainPageViewModel(
                loginViewModel, 
                navigationService, 
                bookService,
                orderService,
                userService);

            viewModel.LoadBooksCommand.Execute(null);
            viewModel.LoadUserInfoCommand.Execute(null);

            if(viewModel.IsAdmin)
            {
                viewModel.LoadReadersCommand.Execute(null);
            }
            else
            {
                viewModel.LoadOrdersCommand.Execute(null);
            }

            return viewModel;
        }

        public void UpdatePrintedEditions(IEnumerable<PrintedEdition> printedEditions)
        {
            PrintedEditions.Clear();

            foreach (var printedEdition in printedEditions) 
            {
                PrintedEditions.Add(new PrintedEditionViewModel(this, printedEdition, _navigationService));
            }
        }

        public void UpdateOrders(IEnumerable<Order> orders)
        {
            OrderViewModels.Clear();

            foreach (var order in orders) 
            {
                OrderViewModels.Add(new OrderViewModel(order, _navigationService, _orderService));
            }
        }

        public void UpdateReades(IEnumerable<User> readers)
        {
            ReaderViewModels.Clear();

            foreach (var reader in readers)
            {
                ReaderViewModels.Add(ReaderViewModel.LoadReaderViewModel(reader, _orderService, _navigationService, _userService));
            }
        }
    }
}
