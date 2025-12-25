using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.DAL.Repositories;
using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.BLL.Services.Implements
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetBookByIdAsync(string bookId)
        {
            if (string.IsNullOrWhiteSpace(bookId))
                throw new ArgumentException("BookID không được để trống");

            return await _bookRepository.GetByIdAsync(bookId);
        }

        public async Task<(bool success, string message)> AddBookAsync(Book book)
        {
            if (!book.IsValid(out string validationMsg))
                return (false, validationMsg);

            if (await _bookRepository.ExistsByBookIdAsync(book.BookID))
                return (false, "Mã sách đã tồn tại!");

            if (await _bookRepository.ExistsByTitleAsync(book.Title))
                return (false, "Tên sách đã tồn tại!");

            if (!string.IsNullOrWhiteSpace(book.Publisher) && book.Publisher.Length > 100)
                return (false, "Tên nhà xuất bản quá dài!");

            bool result = await _bookRepository.AddAsync(book);

            return result
                ? (true, "Thêm sách thành công!")
                : (false, "Thêm sách thất bại!");
        }

        public async Task<(bool success, string message)> UpdateBookAsync(Book book)
        {
            if (!book.IsValid(out string validationMsg))
                return (false, validationMsg);

            var existing = await _bookRepository.GetByIdAsync(book.BookID);
            if (existing == null)
                return (false, "Sách không tồn tại!");

            if (await _bookRepository.ExistsByTitleAsync(book.Title, book.BookID))
                return (false, "Tên sách đã tồn tại!");

            bool result = await _bookRepository.UpdateAsync(book);

            return result
                ? (true, "Cập nhật sách thành công!")
                : (false, "Cập nhật sách thất bại!");
        }

        public async Task<(bool success, string message)> DeleteBookAsync(string bookId)
        {
            if (string.IsNullOrWhiteSpace(bookId))
                return (false, "BookID không được để trống!");

            var existing = await _bookRepository.GetByIdAsync(bookId);
            if (existing == null)
                return (false, "Sách không tồn tại!");

            try
            {
                bool result = await _bookRepository.DeleteAsync(bookId);
                return result
                    ? (true, "Xóa sách thành công!")
                    : (false, "Xóa sách thất bại!");
            }
            catch
            {
                return (false, "Không thể xóa sách vì đang được sử dụng.");
            }
        }

        public async Task<List<Book>> SearchBooksAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllBooksAsync();

            return await _bookRepository.SearchAsync(keyword.Trim());
        }

        public async Task<List<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new ArgumentException("CategoryId không hợp lệ");

            return await _bookRepository.GetByCategoryAsync(categoryId);
        }

        public async Task<bool> IsBookIdExistsAsync(string bookId)
        {
            if (string.IsNullOrWhiteSpace(bookId))
                return false;

            return await _bookRepository.ExistsByBookIdAsync(bookId);
        }
    }
}
