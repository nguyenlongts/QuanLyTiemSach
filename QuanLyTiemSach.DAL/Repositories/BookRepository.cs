using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.Domain.Model;


namespace QuanLyTiemSach.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books
                .Include(b => b.Category)
                .OrderBy(b => b.Title)
                .ToList();
        }

        public Book GetById(string bookId)
        {
            return _context.Books
                .Include(b => b.Category)
                .FirstOrDefault(b => b.BookID == bookId);
        }

        public bool Add(Book book)
        {
            try
            {
                _context.Books.Add(book);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Book book)
        {
            try
            {
                var existing = _context.Books.Find(book.BookID);
                if (existing == null) return false;

                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.Publisher = book.Publisher;
                existing.PublishedYear = book.PublishedYear;
                existing.Price = book.Price;
                existing.Quantity = book.Quantity;
                existing.CategoryId = book.CategoryId;

                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string bookId)
        {
            try
            {
                var book = _context.Books.Find(bookId);
                if (book == null) return false;

                _context.Books.Remove(book);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Book> Search(string keyword)
        {
            return _context.Books
                .Include(b => b.Category)
                .Where(b => b.Title.Contains(keyword) ||
                           b.Author.Contains(keyword) ||
                           b.Publisher.Contains(keyword) ||
                           b.BookID.Contains(keyword))
                .OrderBy(b => b.Title)
                .ToList();
        }

        public List<Book> GetByCategory(int categoryId)
        {
            return _context.Books
                .Include(b => b.Category)
                .Where(b => b.CategoryId == categoryId)
                .OrderBy(b => b.Title)
                .ToList();
        }

        public bool ExistsByBookId(string bookId)
        {
            return _context.Books.Any(b => b.BookID == bookId);
        }

        public bool ExistsByTitle(string title, string excludeBookId = null)
        {
            var query = _context.Books
                .Where(b => b.Title.ToLower() == title.ToLower());

            if (!string.IsNullOrEmpty(excludeBookId))
            {
                query = query.Where(b => b.BookID != excludeBookId);
            }

            return query.Any();
        }
    }
}
