
using QuanLyTiemSach.DAL.Repositories;
using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAllCategories()
        {
            try
            {
                return _categoryRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách danh mục: {ex.Message}");
            }
        }

        public Category GetCategoryById(int id)
        {
            try
            {
                return _categoryRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin danh mục: {ex.Message}");
            }
        }

        public (bool success, string message) AddCategory(Category category)
        {
            try
            {
                // Validate
                if (!category.IsValid(out string validationMsg))
                {
                    return (false, validationMsg);
                }

                // Kiểm tra trùng tên
                if (_categoryRepository.ExistsByName(category.Name))
                {
                    return (false, "Tên danh mục đã tồn tại!");
                }

                // Thêm mới
                bool result = _categoryRepository.Add(category);
                return result
                    ? (true, "Thêm danh mục thành công!")
                    : (false, "Thêm danh mục thất bại!");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public (bool success, string message) UpdateCategory(Category category)
        {
            try
            {
                // Validate
                if (!category.IsValid(out string validationMsg))
                {
                    return (false, validationMsg);
                }

                // Kiểm tra tồn tại
                var existing = _categoryRepository.GetById(category.Id);
                if (existing == null)
                {
                    return (false, "Danh mục không tồn tại!");
                }

                // Kiểm tra trùng tên (trừ chính nó)
                if (_categoryRepository.ExistsByName(category.Name, category.Id))
                {
                    return (false, "Tên danh mục đã tồn tại!");
                }

                // Cập nhật
                bool result = _categoryRepository.Update(category);
                return result
                    ? (true, "Cập nhật danh mục thành công!")
                    : (false, "Cập nhật danh mục thất bại!");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        public (bool success, string message) DeleteCategory(int id)
        {
            try
            {
                // Kiểm tra tồn tại
                var existing = _categoryRepository.GetById(id);
                if (existing == null)
                {
                    return (false, "Danh mục không tồn tại!");
                }

                // Xóa
                bool result = _categoryRepository.Delete(id);
                return result
                    ? (true, "Xóa danh mục thành công!")
                    : (false, "Xóa danh mục thất bại!");
            }
            catch (Exception ex)
            {
                // Có thể do constraint foreign key
                return (false, $"Không thể xóa danh mục này. Có thể đang có sách thuộc danh mục này.");
            }
        }

        public List<Category> SearchCategories(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    return GetAllCategories();
                }

                return _categoryRepository.Search(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi tìm kiếm danh mục: {ex.Message}");
            }
        }
    }
}
