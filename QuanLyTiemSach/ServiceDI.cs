using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.BLL.Services.Implements;
using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.DAL;
using QuanLyTiemSach.DAL.Repositories;
using QuanLyTiemSach.Data.Repositories;
using WorkShiftManagement.Repositories;

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
            IBookRepository bookRepository = new BookRepository(dbContext);
            return new CategoryService(repository,bookRepository);
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

        public static ISalaryService GetSalaryService()
        {
            var dbContext = GetDbContext();
            ISalaryRepository salaryRepository = new SalaryRepository(dbContext);
            IEmployeeRepository employeeRepository = new EmployeeRepository(dbContext);
            WorkShiftRepository workShiftRepository = new WorkShiftRepository(dbContext);

            return new SalaryService(salaryRepository, employeeRepository, workShiftRepository);
        }

        public static IEmployeeService GetEmployeeService()
        {
            var dbContext = GetDbContext();
            IEmployeeRepository repository = new EmployeeRepository(dbContext);
            return new EmployeeService(repository);
        }

        public static WorkShiftService GetWorkShiftService()
        {
            var dbContext = GetDbContext();
            return new WorkShiftService(dbContext);
        }
    }
}