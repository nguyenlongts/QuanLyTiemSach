using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.DAL.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyTiemSach.BLL.Services.Implements
{
    public class StatisticService : IStatisticService
    {
        private readonly IStatisticRepository _statisticRepository;

        public StatisticService(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<Dictionary<string, int>> GetBookSalesAsync()
        {
            return await _statisticRepository.GetBookSalesAsync();
        }
    }
}
