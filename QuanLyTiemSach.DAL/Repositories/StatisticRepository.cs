using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyTiemSach.DAL.Repositories
{
    public class StatisticRepository : IStatisticRepository
    {
        private readonly BookStoreDbContext _context;

        public StatisticRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, int>> GetBookSalesAsync()
        {
            return await _context.OrderDetails
                .Include(od => od.Book)
                .GroupBy(od => od.Book.Title)
                .Select(g => new
                {
                    BookTitle = g.Key,
                    TotalQuantity = g.Sum(x => x.Quantity)
                })
                .ToDictionaryAsync(x => x.BookTitle, x => x.TotalQuantity);
        }
    }
}
