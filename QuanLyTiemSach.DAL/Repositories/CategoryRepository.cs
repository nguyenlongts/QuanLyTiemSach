using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public List<Category> GetAll()
        {
            return _context.Categories
                .OrderBy(c => c.Name)
                .ToList();
        }

        public Category GetById(int id)
        {
            return _context.Categories.Find(id);
        }

        public bool Add(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Category category)
        {
            try
            {
                var existing = _context.Categories.Find(category.Id);
                if (existing == null) return false;

                existing.Name = category.Name;
                existing.Description = category.Description;

                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var category = _context.Categories.Find(id);
                if (category == null) return false;

                _context.Categories.Remove(category);
                return _context.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public List<Category> Search(string keyword)
        {
            return _context.Categories
                .Where(c => c.Name.Contains(keyword) || c.Description.Contains(keyword))
                .OrderBy(c => c.Name)
                .ToList();
        }

        public bool ExistsByName(string name, int? excludeId = null)
        {
            var query = _context.Categories
                .Where(c => c.Name.ToLower() == name.ToLower());

            if (excludeId.HasValue)
            {
                query = query.Where(c => c.Id != excludeId.Value);
            }

            return query.Any();
        }
    }
}
