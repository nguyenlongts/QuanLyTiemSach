using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.BLL.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(string bookId);
        Task<(bool success, string message)> AddBookAsync(Book book);
        Task<(bool success, string message)> UpdateBookAsync(Book book);
        Task<(bool success, string message)> DeleteBookAsync(string bookId);
        Task<List<Book>> SearchBooksAsync(string keyword);
        Task<List<Book>> GetBooksByCategoryAsync(int categoryId);
        Task<bool> IsBookIdExistsAsync(string bookId);
    }
}
