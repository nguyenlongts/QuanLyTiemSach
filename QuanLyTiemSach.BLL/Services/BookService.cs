using QuanLyTiemSach.DAL;
using QuanLyTiemSach.DAL.Repositories;
using QuanLyTiemSach.Domain.Model;


namespace QuanLyTiemSach.BLL.Services
{
    public class BookService: IBookService
    {
        private readonly BookStoreDbContext _context;

        public BookService()
        {
            _context = new BookStoreDbContext();
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book? GetById(string id)
        {
            return _context.Books.FirstOrDefault(x => x.BookID == id);
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

        public void Delete(string id)
        {
            var book = GetById(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
