using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.BLL.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(string bookId);

        Task AddBookAsync(Book book);
        Task UpdateBookAsync(Book book);
        Task DeleteBookAsync(string bookId);

        Task<List<Book>> SearchBooksAsync(string keyword);
        Task<List<Book>> GetBooksByCategoryAsync(int categoryId);
        Task<bool> IsBookIdExistsAsync(string bookId);
    }
}
