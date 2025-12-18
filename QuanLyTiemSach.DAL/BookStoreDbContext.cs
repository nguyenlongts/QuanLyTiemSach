using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.Domain.Model;


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

        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
