using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyTiemSach.DAL.Repositories
{
    public interface IStatisticRepository
    {
        Task<Dictionary<string, int>> GetBookSalesAsync();
    }
}
