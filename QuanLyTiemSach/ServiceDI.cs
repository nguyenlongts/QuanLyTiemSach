using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.DAL;
using QuanLyTiemSach.DAL.Repositories;

namespace QuanLyTiemSach
{
    public static class ServiceDI
    {
        private static BookStoreDbContext _dbContext;

        public static BookStoreDbContext GetDbContext()
        {
            if (_dbContext == null)
            {
                _dbContext = new BookStoreDbContext();
            }
            return _dbContext;
        }

        public static ICategoryService GetCategoryService()
        {
            var dbContext = GetDbContext();
            ICategoryRepository repository = new CategoryRepository(dbContext);
            return new CategoryService(repository);
        }

        public static IBookService GetBookService()
        {
            var dbContext = GetDbContext();
            IBookRepository repository = new BookRepository(dbContext);
            return new BookService(repository);
        }

        public static IOrderService GetOrderService()
        {
            var dbContext = GetDbContext();
            IOrderRepository orderRepository = new OrderRepository(dbContext);
            IBookRepository bookRepository = new BookRepository(dbContext);
            return new OrderService(orderRepository, bookRepository);
        }

        public static ICustomerService GetCustomerService()
        {
            var dbContext = GetDbContext();
            ICustomerRepository repository = new CustomerRepository(dbContext);
            return new CustomerService(repository);
        }
        
        public static IStatisticService GetStatisticService()
        {
            var dbContext = GetDbContext();
            IStatisticRepository repository = new StatisticRepository(dbContext);
            return new StatisticService(repository);
        }
    }
}