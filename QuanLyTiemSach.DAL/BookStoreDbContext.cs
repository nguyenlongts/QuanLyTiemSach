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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình Book
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.BookID);

                entity.Property(e => e.BookID)
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsRequired();

                entity.Property(e => e.Author)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.Publisher)
                    .HasMaxLength(100);

                entity.Property(e => e.Quantity)
                    .HasDefaultValue(0);

                // Relationship với Category
                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Books)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Index
                entity.HasIndex(e => e.Title);
                entity.HasIndex(e => e.CategoryId);
            });


            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(500);

                // Index
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }
    }
}
