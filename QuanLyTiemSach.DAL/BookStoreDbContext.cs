
using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.Model;

namespace QuanLyTiemSach.DAL
{
    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options) { }

        public DbSet<Book> Books
        {get;set;}
    }
}
