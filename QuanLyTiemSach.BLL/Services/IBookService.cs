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
        List<Book> GetAll();
        Book? GetById(string id);
        void Add(Book book);
        void Update(Book book);
        void Delete(string id);
    }
}
