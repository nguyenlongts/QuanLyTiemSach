using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.DAL.Repositories;
using QuanLyTiemSach.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookRepository _bookRepository;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IBookRepository bookRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await _categoryRepository.GetByIdAsync(id);
        }

        public async Task<bool> ExistsByNameAsync(string name, int? excludeId = null)
        {
            return await _categoryRepository.ExistsByNameAsync(name, excludeId);
        }

        public async Task AddCategoryAsync(Category category)
        {
            if (!category.IsValid(out string msg))
                throw new Exception(msg);

            if (await _categoryRepository.ExistsByNameAsync(category.Name))
                throw new Exception("Tên danh mục đã tồn tại!");

            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            var existing = await _categoryRepository.GetByIdAsync(category.Id);
            if (existing == null)
                throw new Exception("Danh mục không tồn tại!");

            if (await _categoryRepository.ExistsByNameAsync(category.Name, category.Id))
                throw new Exception("Tên danh mục đã tồn tại!");

            await _categoryRepository.UpdateAsync(category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
                throw new Exception("Danh mục không tồn tại!");

            var books = await _bookRepository.GetByCategoryAsync(id);

            if (books.Any())
                throw new Exception("Không thể xoá danh mục đang chứa sách!");

            await _categoryRepository.DeleteAsync(id);
        }

        public async Task<List<Category>> SearchCategoriesAsync(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return await GetAllCategoriesAsync();

            return await _categoryRepository.SearchAsync(keyword);
        }
    }
}
