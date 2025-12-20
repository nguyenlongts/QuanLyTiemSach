using QuanLyTiemSach.DAL;
using QuanLyTiemSach.DAL.Repositories;
using QuanLyTiemSach.Domain.Model;


namespace QuanLyTiemSach.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                return _bookRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách sách: {ex.Message}");
            }
        }

        public Book GetBookById(string bookId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(bookId))
                    throw new ArgumentException("BookID không được để trống");

                return _bookRepository.GetById(bookId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin sách: {ex.Message}");
            }
        }

        public (bool success, string message) AddBook(Book book)
        {
            try
            {
                // Validate using Book's IsValid method
                if (!book.IsValid(out string validationMsg))
                {
                    return (false, validationMsg);
                }

                // Kiểm tra trùng BookID
                if (_bookRepository.ExistsByBookId(book.BookID))
                {
                    return (false, "Mã sách đã tồn tại!");
                }

                // Kiểm tra trùng Title
                if (_bookRepository.ExistsByTitle(book.Title))
                {
                    return (false, "Tên sách đã tồn tại!");
                }

                // Validate Publisher nếu có
                if (!string.IsNullOrWhiteSpace(book.Publisher) && book.Publisher.Length > 100)
                {
                    return (false, "Tên nhà xuất bản quá dài (tối đa 100 ký tự)!");
                }

                // Thêm mới
                bool result = _bookRepository.Add(book);
                return result
                    ? (true, "Thêm sách thành công!")
                    : (false, "Thêm sách thất bại!");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public (bool success, string message) UpdateBook(Book book)
        {
            try
            {
                // Validate using Book's IsValid method
                if (!book.IsValid(out string validationMsg))
                {
                    return (false, validationMsg);
                }

                // Kiểm tra tồn tại
                var existing = _bookRepository.GetById(book.BookID);
                if (existing == null)
                {
                    return (false, "Sách không tồn tại!");
                }

                // Kiểm tra trùng Title (trừ chính nó)
                if (_bookRepository.ExistsByTitle(book.Title, book.BookID))
                {
                    return (false, "Tên sách đã tồn tại!");
                }

                // Validate Publisher nếu có
                if (!string.IsNullOrWhiteSpace(book.Publisher) && book.Publisher.Length > 100)
                {
                    return (false, "Tên nhà xuất bản quá dài (tối đa 100 ký tự)!");
                }

                // Cập nhật
                bool result = _bookRepository.Update(book);
                return result
                    ? (true, "Cập nhật sách thành công!")
                    : (false, "Cập nhật sách thất bại!");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public (bool success, string message) DeleteBook(string bookId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(bookId))
                {
                    return (false, "BookID không được để trống!");
                }

                // Kiểm tra tồn tại
                var existing = _bookRepository.GetById(bookId);
                if (existing == null)
                {
                    return (false, "Sách không tồn tại!");
                }

                // Xóa
                bool result = _bookRepository.Delete(bookId);
                return result
                    ? (true, "Xóa sách thành công!")
                    : (false, "Xóa sách thất bại!");
            }
            catch (Exception ex)
            {
                // Có thể do foreign key constraint
                return (false, "Không thể xóa sách này. Sách đang có trong đơn hàng.");
            }
        }

        public List<Book> SearchBooks(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    return GetAllBooks();
                }

                return _bookRepository.Search(keyword.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm sách: {ex.Message}");
            }
        }

        public List<Book> GetBooksByCategory(int categoryId)
        {
            try
            {
                if (categoryId <= 0)
                {
                    throw new ArgumentException("CategoryId không hợp lệ");
                }

                return _bookRepository.GetByCategory(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy sách theo danh mục: {ex.Message}");
            }
        }

        public bool IsBookIdExists(string bookId)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(bookId))
                    return false;

                return _bookRepository.ExistsByBookId(bookId);
            }
            catch
            {
                return false;
            }
        }
    }
}
