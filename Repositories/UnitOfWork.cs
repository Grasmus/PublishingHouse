using PublishingHouse.DataAccessLayer;
using System.Threading.Tasks;

namespace PublishingHouse.Repositories
{
    public class UnitOfWork
    {
        private PublishingHouseContext _context;
        private UserRepository _userRepository;
        private PrintedEditionRepository _printedEditionRepository;
        private OrderRepository _orderRepository;
        private CategoryRepository _categoryRepository;

        public UnitOfWork(PublishingHouseContext context)
        {
            _context = context;
        }

        public UserRepository UserRepository
        {
            get
            {
                if(_userRepository == null)
                {
                    _userRepository = new UserRepository(_context.User);
                }

                return _userRepository;
            }
        }

        public PrintedEditionRepository PrintedEditionRepository
        {
            get
            {
                if (_printedEditionRepository == null)
                {
                    _printedEditionRepository = new PrintedEditionRepository(_context.PrintedEdition);
                }

                return _printedEditionRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if(_orderRepository == null)
                {
                    _orderRepository = new OrderRepository(_context.Order);
                }

                return _orderRepository;
            }
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                if(_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context.Category);
                }

                return _categoryRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose() 
        {
            _context.Dispose();
        }
    }
}
