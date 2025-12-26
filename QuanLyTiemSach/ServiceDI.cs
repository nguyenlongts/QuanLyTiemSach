using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.BLL.Services.Implements;
using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.DAL;
using QuanLyTiemSach.DAL.Repositories;
using QuanLyTiemSach.Data.Repositories;

namespace QuanLyTiemSach
{
    public static class ServiceDI
    {

        public static BookStoreDbContext GetDbContext()
        {
            return new BookStoreDbContext();
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
            IShiftRepository workShiftRepository = new WorkShiftRepository(dbContext);

            return new SalaryService(salaryRepository, employeeRepository, workShiftRepository);
        }

        public static IEmployeeService GetEmployeeService()
        {
            var dbContext = GetDbContext();
            IEmployeeRepository repository = new EmployeeRepository(dbContext);
            return new EmployeeService(repository);
        }
        public static IUserService GetUserService()
        {
            var dbContext = GetDbContext();
            IUserRepository repository = new UserRepository(dbContext);
            IEmployeeRepository employeeRepository = new EmployeeRepository(dbContext);
            return new UserService(repository, employeeRepository, dbContext);
        }

        public static IShiftService GetWorkShiftService()
        {
            var dbContext = GetDbContext();

            IShiftRepository shiftRepository = new WorkShiftRepository(dbContext);
            IEmployeeRepository employeeRepository = new EmployeeRepository(dbContext);

            return new WorkShiftService(shiftRepository, employeeRepository);
        }

    }
}