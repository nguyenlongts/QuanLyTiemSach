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
            try
            {
                return await _bookRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể tải danh sách sách.", ex);
            }
        }

        public async Task<Book?> GetBookByIdAsync(string bookId)
        {
            if (string.IsNullOrWhiteSpace(bookId))
                throw new Exception("BookID không được để trống.");

            try
            {
                return await _bookRepository.GetByIdAsync(bookId);
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể lấy thông tin sách.", ex);
            }
        }

        public async Task AddBookAsync(Book book)
        {
            if (!book.IsValid(out string validationMsg))
                throw new Exception(validationMsg);

            if (await _bookRepository.ExistsByBookIdAsync(book.BookID))
                throw new Exception("Mã sách đã tồn tại!");

            if (await _bookRepository.ExistsByTitleAsync(book.Title))
                throw new Exception("Tên sách đã tồn tại!");

            if (!string.IsNullOrWhiteSpace(book.Publisher) &&
                book.Publisher.Length > 100)
                throw new Exception("Tên nhà xuất bản quá dài!");

            await _bookRepository.AddAsync(book);
        }


        public async Task UpdateBookAsync(Book book)
        {
            try
            {
                if (!book.IsValid(out string validationMsg))
                    throw new Exception(validationMsg);

                var existing = await _bookRepository.GetByIdAsync(book.BookID);
                if (existing == null)
                    throw new Exception("Sách không tồn tại!");

                if (await _bookRepository.ExistsByTitleAsync(book.Title, book.BookID))
                    throw new Exception("Tên sách đã tồn tại!");

                bool result = await _bookRepository.UpdateAsync(book);
                if (!result)
                    throw new Exception("Cập nhật sách thất bại!");
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteBookAsync(string bookId)
        {
            if (string.IsNullOrWhiteSpace(bookId))
                throw new Exception("BookID không được để trống.");

            try
            {
                var existing = await _bookRepository.GetByIdAsync(bookId);
                if (existing == null)
                    throw new Exception("Sách không tồn tại!");

                bool result = await _bookRepository.DeleteAsync(bookId);
                if (!result)
                    throw new Exception("Xóa sách thất bại!");
            }
            catch
            {
                throw new Exception("Không thể xóa sách vì đang được sử dụng.");
            }
        }

        public async Task<List<Book>> SearchBooksAsync(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                    return await GetAllBooksAsync();

                return await _bookRepository.SearchAsync(keyword.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm sách.", ex);
            }
        }

        public async Task<List<Book>> GetBooksByCategoryAsync(int categoryId)
        {
            if (categoryId <= 0)
                throw new Exception("CategoryId không hợp lệ.");

            try
            {
                return await _bookRepository.GetByCategoryAsync(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể tải sách theo danh mục.", ex);
            }
        }

        public async Task<bool> IsBookIdExistsAsync(string bookId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(bookId))
                    return false;

                return await _bookRepository.ExistsByBookIdAsync(bookId);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra mã sách.", ex);
            }
        }
    }
}
