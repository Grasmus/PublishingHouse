using PublishingHouse.Commands;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.CategoryEntity;
using PublishingHouse.Models.OrderEntity;
using PublishingHouse.Models.PrintedEditionEntity;
using PublishingHouse.Models.UserEntity;
using PublishingHouse.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PublishingHouse.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        private readonly ICategoryService _categoryService;
        private readonly IPrintedEditionService _printedEditionService;

        public bool IsAdmin { get; set; }
        public bool IsReader { get; set; }

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

        public bool HasPrintedEditions => PrintedEditions.Any();

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

        private bool _hasCartItems;

        public bool HasCartItems
        {
            get => _hasCartItems;

            set
            {
                _hasCartItems = value;

                OnPropertyChanged();
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

        private bool _hasOrders;

        public bool HasOrders
        {
            get => _hasOrders;

            set
            {
                _hasOrders = value;

                OnPropertyChanged();
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

        public bool HasReaders => ReaderViewModels.Any();

        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new ObservableCollection<Category>();
                }

                return _categories;
            }

            set
            {
                _categories = value;
            }
        }

        private int _userId;

        public int UserId
        {
            get => _userId;

            set
            {
                _userId = value;

                OnPropertyChanged();
            }
        }

        private string _firstName;

        public string FirstName
        {
            get => _firstName;

            set
            {
                _firstName = value;

                OnPropertyChanged();
            }
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;

            set
            {
                _lastName = value;

                OnPropertyChanged();
            }
        }

        private string _login;

        public string Login
        {
            get => _login;

            set
            {
                _login = value;

                OnPropertyChanged();
            }
        }

        private bool _isUserBlacklisted;

        public bool IsUserBlacklisted
        {
            get => _isUserBlacklisted;
                
            set
            {
                _isUserBlacklisted = value;

                OnPropertyChanged();
            }
        }

        private decimal _totalSum;

        public decimal TotalSum
        {
            get => _totalSum;

            set
            {
                _totalSum = value;

                OnPropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get => _title;

            set
            {
                _title = value;

                OnPropertyChanged();
            }
        }

        private string _author;

        public string Author
        {
            get => _author;

            set
            {
                _author = value;

                OnPropertyChanged();
            }
        }

        private string? _description;

        public string? Description
        {
            get => _description;

            set
            {
                _description = value;

                OnPropertyChanged();
            }
        }

        private string _genre;

        public string Genre
        {
            get => _genre;

            set
            {
                _genre = value;

                OnPropertyChanged();
            }
        }

        private string _language;

        public string Language
        {
            get => _language;

            set
            {
                _language = value;

                OnPropertyChanged();
            }
        }

        private byte[]? _cover;

        public byte[]? Cover
        {
            get => _cover;

            set
            {
                _cover = value;

                OnPropertyChanged();
            }
        }

        private string _price;

        public string Price
        {
            get => _price;

            set
            {
                _price = value;

                OnPropertyChanged();
            }
        }

        private DateTime _releaseDate;

        public DateTime ReleaseDate
        {
            get => _releaseDate;

            set
            {
                _releaseDate = value;

                OnPropertyChanged();
            }
        }

        private bool _isAvailable;

        public bool IsAvailable
        {
            get => _isAvailable; 
            
            set
            {
                _isAvailable = value;

                OnPropertyChanged();
            }
        }

        private Category _category;

        public Category Category
        {
            get => _category;

            set
            {
                _category = value;

                OnPropertyChanged();
            }
        }

        ICommand LoadUserInfoCommand { get; }
        ICommand LoadReadersCommand { get; }
        ICommand LoadCategoriesCommand { get; }
        public ICommand LoadBooksCommand { get; }
        public ICommand LoadOrdersCommand {  get; }
        public ICommand UpdateUserInfoCommand { get; }
        public ICommand LogoutCommand { get; }
        public ICommand DeleteUserCommand { get; }
        public ICommand MakeOrderCommand { get; }
        public ICommand LoadImageCommand { get; }
        public ICommand CreatePrintedEditionCommand { get; }

        public MainPageViewModel(
            LoginViewModel loginViewModel, 
            INavigationService navigationService, 
            IPrintedEditionService bookService,
            IOrderService orderService,
            IUserService userService,
            ICategoryService categoryService,
            IPrintedEditionService printedEditionService)
        {
            _navigationService = navigationService;
            _orderService = orderService;
            _userService = userService;
            _categoryService = categoryService;
            _printedEditionService = printedEditionService;

            LoadBooksCommand = new LoadBooksCommand(this, bookService);
            LoadUserInfoCommand = new LoadUserInfoCommand(this, userService);
            LoadOrdersCommand = new LoadMainPageOrdersCommand(this, orderService);
            LoadReadersCommand = new LoadReadersCommand(UpdateReades, userService);
            LoadCategoriesCommand = new LoadCategoriesCommand(UpdateCategories, categoryService);
            UpdateUserInfoCommand = new UpdateUserInfoCommand(this, userService);
            LogoutCommand = new LogoutCommand(loginViewModel, navigationService);
            DeleteUserCommand = new DeleteUserCommand(this, userService);
            MakeOrderCommand = new MakeOrderCommand(this, orderService, userService);
            LoadImageCommand = new LoadImageCommand(UpdateCover);
            CreatePrintedEditionCommand = new CreatePrintedEditionCommand(this, bookService);
        }

        public static MainPageViewModel LoadViewModel(
            LoginViewModel loginViewModel,
            INavigationService navigationService, 
            IPrintedEditionService printedEditionService,
            IOrderService orderService,
            IUserService userService,
            ICategoryService categoryService)
        {
            var viewModel = new MainPageViewModel(
                loginViewModel, 
                navigationService, 
                printedEditionService,
                orderService,
                userService,
                categoryService,
                printedEditionService);

            viewModel.LoadBooksCommand.Execute(null);
            viewModel.LoadUserInfoCommand.Execute(null);

            if(viewModel.IsAdmin)
            {
                viewModel.LoadReadersCommand.Execute(null);
                viewModel.LoadCategoriesCommand.Execute(null);
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
                PrintedEditions.Add(new PrintedEditionViewModel(
                    this, 
                    printedEdition, 
                    _navigationService, 
                    _categoryService, 
                    _printedEditionService));
            }
        }

        public void UpdateOrders(IEnumerable<Order> orders)
        {
            OrderViewModels.Clear();

            HasOrders = orders.Any();

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

        public void UpdateCategories(IEnumerable<Category> categories)
        {
            Categories.Clear();

            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }

        public void UpdateCover(byte[]? cover)
        {
            Cover = cover;
        }
    }
}
