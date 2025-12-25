using QuanLyTiemSach.Domain.Model;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<bool> AddCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);

        Task<bool> DeleteCategoryAsync(int id);

        Task<List<Category>> SearchCategoriesAsync(string keyword);
        Task<bool> ExistsByNameAsync(string name, int? excludeId = null);
    }
}
