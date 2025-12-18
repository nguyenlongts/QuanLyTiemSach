using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.Model;

namespace QuanLyTiemSach.DAL
{
    public class BookStoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(
                "server=localhost;database=bookstore_db;user=bookstore;password=123456;",
                ServerVersion.AutoDetect(
                    "server=localhost;database=bookstore_db;user=bookstore;password=123456;"
                )
            );
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
