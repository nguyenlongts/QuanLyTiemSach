using QuanLyTiemSach.Domain.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyTiemSach.DAL.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<bool> AddAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<List<Category>> SearchAsync(string keyword);
        Task<bool> ExistsByNameAsync(string name, int? excludeId = null);
        Task<Category?> GetWithBooksAsync(int id);
    }
}
