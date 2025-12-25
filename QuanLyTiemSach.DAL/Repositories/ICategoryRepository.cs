using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.DAL.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        bool Add(Category category);
        bool Update(Category category);
        bool Delete(int id);
        List<Category> Search(string keyword);
        bool ExistsByName(string name, int? excludeId = null);
    }
}
