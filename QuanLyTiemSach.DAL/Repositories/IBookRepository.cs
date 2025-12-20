using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.DAL.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book GetById(string bookId);
        bool Add(Book book);
        bool Update(Book book);
        bool Delete(string bookId);
        List<Book> Search(string keyword);
        List<Book> GetByCategory(int categoryId);
        bool ExistsByBookId(string bookId);
        bool ExistsByTitle(string title, string excludeBookId = null);
    }
}
