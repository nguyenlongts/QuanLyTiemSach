using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        (bool success, string message) AddCategory(Category category);
        (bool success, string message) UpdateCategory(Category category);
        (bool success, string message) DeleteCategory(int id);
        List<Category> SearchCategories(string keyword);
    }
}
