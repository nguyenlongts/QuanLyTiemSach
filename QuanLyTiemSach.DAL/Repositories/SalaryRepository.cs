using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.DAL;
using QuanLyTiemSach.Domain.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyTiemSach.Data.Repositories
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly BookStoreDbContext _context;

        public SalaryRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Salary>> GetAllAsync()
        {
            return await _context.Salaries
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Salary?> GetByIdAsync(int id)
        {
            return await _context.Salaries
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Salary?> GetByEmployeeAndMonthAsync(int employeeId, int month)
        {
            return await _context.Salaries
                .FirstOrDefaultAsync(s =>
                    s.EmployeeId == employeeId &&
                    s.Month == month);
        }

        public async Task<List<Salary>> GetByEmployeeIdAsync(int employeeId)
        {
            return await _context.Salaries
                .Where(s => s.EmployeeId == employeeId)
                .OrderByDescending(s => s.Month)
                .ToListAsync();
        }

        public async Task<List<Salary>> GetByMonthAsync(int month)
        {
            return await _context.Salaries
                .Where(s => s.Month == month)
                .OrderBy(s => s.EmployeeId)
                .ToListAsync();
        }

        public async Task AddAsync(Salary salary)
        {
            await _context.Salaries.AddAsync(salary);
        }

        public Task UpdateAsync(Salary salary)
        {
            _context.Salaries.Update(salary);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Salary salary)
        {
            _context.Salaries.Remove(salary);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int employeeId, int month)
        {
            return await _context.Salaries
                .AnyAsync(s => s.EmployeeId == employeeId && s.Month == month);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
