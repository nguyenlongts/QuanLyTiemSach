using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyTiemSach.DAL.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookStoreDbContext _context;

        public CategoryRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> GetWithBooksAsync(int id)
        {
            return await _context.Categories
                .Include(c => c.Books)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> AddAsync(Category category)
        {
            try
            {
                await _context.Categories.AddAsync(category);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            try
            {
                var existing = await _context.Categories.FindAsync(category.Id);
                if (existing == null) return false;

                existing.Name = category.Name;
                existing.Description = category.Description;

                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var category = await _context.Categories.FindAsync(id);
                if (category == null) return false;

                _context.Categories.Remove(category);
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Category>> SearchAsync(string keyword)
        {
            return await _context.Categories
                .Where(c =>
                    c.Name.Contains(keyword) ||
                    c.Description.Contains(keyword))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name, int? excludeId = null)
        {
            var query = _context.Categories
                .Where(c => c.Name.ToLower() == name.ToLower());

            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }

            return await query.AnyAsync();
        }
    }
}
