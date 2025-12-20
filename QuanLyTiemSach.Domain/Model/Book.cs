using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyTiemSach.Domain.Model
{
    public class Book
    {
        [Key]
        [Column("BookID")]
        public string BookID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MaxLength(100)]
        public string Author { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [MaxLength(100)]
        public string Publisher { get; set; }

        public int? PublishedYear { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

        // Foreign Key
        [Required]
        public int CategoryId { get; set; }

        // Navigation Property
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        // Navigation cho OrderDetails (nếu có)
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Book()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Book(string bookID, string title, string author, decimal price)
        {
            BookID = bookID;
            Title = title;
            Author = author;
            Price = price;
            Quantity = 0;
            OrderDetails = new HashSet<OrderDetail>();
        }

        /// <summary>
        /// Validate thông tin sách
        /// </summary>
        public bool IsValid(out string msg)
        {
            msg = string.Empty;

            if (string.IsNullOrWhiteSpace(BookID))
            {
                msg = "Chưa nhập mã sách";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Title))
            {
                msg = "Tiêu đề không được để trống";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Author))
            {
                msg = "Chưa nhập tên tác giả";
                return false;
            }

            if (Price <= 0)
            {
                msg = "Giá phải lớn hơn 0";
                return false;
            }

            if (Quantity < 0)
            {
                msg = "Số lượng không được âm";
                return false;
            }

            if (CategoryId <= 0)
            {
                msg = "Chưa chọn danh mục";
                return false;
            }

            if (PublishedYear.HasValue && (PublishedYear < 1000 || PublishedYear > DateTime.Now.Year))
            {
                msg = "Năm xuất bản không hợp lệ";
                return false;
            }

            return true;
        }

        /// <summary>
        /// Tính tổng giá trị tồn kho
        /// </summary>
        public decimal TotalValue => Price * Quantity;

        /// <summary>
        /// Kiểm tra còn hàng
        /// </summary>
        public bool IsAvailable => Quantity > 0;

        /// <summary>
        /// Display format cho ComboBox, ListBox
        /// </summary>
        public override string ToString()
        {
            return $"{BookID} - {Title} ({Author})";
        }
    }
}