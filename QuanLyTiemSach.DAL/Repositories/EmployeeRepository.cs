using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.DAL;
using QuanLyTiemSach.DAL.Repositories;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BookStoreDbContext _context;

        public EmployeeRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees.AsNoTracking().ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task AddAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
        }

        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees.Update(employee);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Employee employee)
        {
            _context.Employees.Remove(employee);
            await Task.CompletedTask;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Employees.AnyAsync(e => e.EmployeeId == id);
        }
        public async Task<int> CountAsync()
        {
            return await _context.Employees.CountAsync();
        }

    }
}
