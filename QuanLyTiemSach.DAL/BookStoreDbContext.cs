using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.Domain.Model;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.DAL
{
    public class BookStoreDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(
                "server=localhost;database=bookstore_db;user=root;password=3132004;",
                ServerVersion.AutoDetect(
                    "server=localhost;database=bookstore_db;user=root;password=3132004;"
                )
            );
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<WorkShift> WorkShifts { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

                entity.HasOne(e => e.Category)
                    .WithMany(c => c.Books)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

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

                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsRequired();
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsRequired();

                entity.Property(e => e.Address)
                    .HasMaxLength(200);
                entity.HasIndex(e => e.PhoneNumber).IsUnique();

            });
            modelBuilder.Entity<OrderDetail>()
      .HasOne(od => od.Book)
      .WithMany(b => b.OrderDetails)
      .HasForeignKey(od => od.BookID)
      .HasPrincipalKey(b => b.BookID)
      .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.OrderDate)
                    .IsRequired();
                entity.Property(e => e.TotalAmount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.HasOne(e => e.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(e => e.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Index
                entity.HasIndex(e => e.OrderDate);
                entity.HasIndex(e => e.CustomerId);
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Quantity)
                    .IsRequired();
                entity.Property(e => e.UnitPrice)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.HasOne(e => e.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(e => e.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Book)
                    .WithMany()
                    .HasForeignKey(e => e.BookID)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.OrderId);
                entity.HasIndex(e => e.BookID);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employees");
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20);


                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(true);

                entity.HasIndex(e => e.EmployeeCode).IsUnique();
            });

            // Cấu hình WorkShift
            modelBuilder.Entity<WorkShift>(entity =>
            {
                entity.ToTable("WorkShifts");
                entity.HasKey(w => w.WorkShiftId);

                entity.Property(w => w.WorkDate)
                    .IsRequired()
                    .HasColumnType("date");

                entity.Property(w => w.ShiftType)
                    .IsRequired();

                entity.Property(w => w.Note)
                    .HasMaxLength(200);

                entity.Property(w => w.CreatedAt)
                    .HasDefaultValueSql("GETDATE()");

                // Relationship
                entity.HasOne(w => w.Employee)
                    .WithMany()
                    .HasForeignKey(w => w.EmployeeId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Unique constraint
                entity.HasIndex(w => new { w.EmployeeId, w.WorkDate, w.ShiftType })
                    .IsUnique();

                // Additional indexes
                entity.HasIndex(w => w.WorkDate);
                entity.HasIndex(w => w.EmployeeId);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("Salary");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.EmployeeId)
                    .IsRequired();

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.Month)
                    .IsRequired();

                // Create unique index for EmployeeId + Month
                entity.HasIndex(e => new { e.EmployeeId, e.Month })
                    .IsUnique()
                    .HasDatabaseName("IX_Salary_EmployeeId_Month");
            });
        }
    }
}