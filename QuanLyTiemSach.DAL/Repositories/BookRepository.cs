using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.Domain.Model;


namespace QuanLyTiemSach.DAL.Repositories
{
    public class BookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository()
        {
            _context = new BookStoreDbContext();
        }

        public List<Book> GetAll()
        {
            return _context.Books
                .Include(b => b.Category)
                .ToList();
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
