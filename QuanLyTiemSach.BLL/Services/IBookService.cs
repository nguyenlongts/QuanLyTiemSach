using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(string bookId);
        (bool success, string message) AddBook(Book book);
        (bool success, string message) UpdateBook(Book book);
        (bool success, string message) DeleteBook(string bookId);
        List<Book> SearchBooks(string keyword);
        List<Book> GetBooksByCategory(int categoryId);
        bool IsBookIdExists(string bookId);
    }
}
