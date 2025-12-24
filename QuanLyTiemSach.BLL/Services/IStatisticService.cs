using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services
{
    public interface IStatisticService
    {
        Task<Dictionary<string, int>> GetBookSalesAsync();
    }
}
