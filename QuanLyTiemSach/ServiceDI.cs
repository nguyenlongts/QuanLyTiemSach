using QuanLyTiemSach.BLL.Services;
using QuanLyTiemSach.DAL;
using QuanLyTiemSach.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
