using System;
using System.ComponentModel.DataAnnotations;

namespace QuanLyTiemSach.Model
{
    public class Book
    {
        public string BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }


        public Book()
        {
        }

        public Book(string bookID, string title, string author, decimal price)
        {
            BookID = bookID;
            Title = title;
            Author = author;
            Price = price;
        }


        public bool IsValid(out string msg)
        {
            msg = string.Empty;

            if (string.IsNullOrWhiteSpace(BookID))
            {
                msg = "Chưa nhập Id";
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
                msg = "Giá không hợp lệ";
                return false;
            }

            return true;
        }






    }
}