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

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Category)
                .OrderBy(b => b.Title)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(string bookId)
        {
            return await _context.Books
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.BookID == bookId);
        }

        public async Task<bool> AddAsync(Book book)
        {
            try
            {
                await _context.Books.AddAsync(book);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Book book)
        {
            try
            {
                var existing = await _context.Books
                    .FirstOrDefaultAsync(b => b.BookID == book.BookID);

                if (existing == null) return false;

                existing.Title = book.Title;
                existing.Author = book.Author;
                existing.Publisher = book.Publisher;
                existing.PublishedYear = book.PublishedYear;
                existing.Price = book.Price;
                existing.Quantity = book.Quantity;
                existing.CategoryId = book.CategoryId;

                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(string bookId)
        {
            try
            {
                var book = await _context.Books
                    .FirstOrDefaultAsync(b => b.BookID == bookId);

                if (book == null) return false;

                _context.Books.Remove(book);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Book>> SearchAsync(string keyword)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Where(b =>
                    b.Title.Contains(keyword) ||
                    b.Author.Contains(keyword) ||
                    b.Publisher.Contains(keyword) ||
                    b.BookID.Contains(keyword))
                .OrderBy(b => b.Title)
                .ToListAsync();
        }

        public async Task<List<Book>> GetByCategoryAsync(int categoryId)
        {
            return await _context.Books
                .Include(b => b.Category)
                .Where(b => b.CategoryId == categoryId)
                .OrderBy(b => b.Title)
                .ToListAsync();
        }

        public async Task<bool> ExistsByBookIdAsync(string bookId)
        {
            return await _context.Books
                .AnyAsync(b => b.BookID == bookId);
        }

        public async Task<bool> ExistsByTitleAsync(string title, string? excludeBookId = null)
        {
            var query = _context.Books
                .Where(b => b.Title.ToLower() == title.ToLower());

            if (!string.IsNullOrEmpty(excludeBookId))
            {
                query = query.Where(b => b.BookID != excludeBookId);
            }

            return await query.AnyAsync();
        }
    }
}
