using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.DAL.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(string bookId);
        Task<bool> AddAsync(Book book);
        Task<bool> UpdateAsync(Book book);
        Task<bool> DeleteAsync(string bookId);
        Task<List<Book>> SearchAsync(string keyword);
        Task<List<Book>> GetByCategoryAsync(int categoryId);
        Task<bool> ExistsByBookIdAsync(string bookId);
        Task<bool> ExistsByTitleAsync(string title, string? excludeBookId = null);
        Task SaveChangeAsync();
    }
}
