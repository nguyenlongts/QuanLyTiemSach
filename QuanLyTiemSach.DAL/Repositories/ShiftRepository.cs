using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using WorkShiftManagement.Models;

namespace QuanLyTiemSach.DAL.Repositories
{
    public class WorkShiftRepository : IShiftRepository
    {
        private readonly BookStoreDbContext _context;

        public WorkShiftRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(WorkShift workShift)
        {
            await _context.WorkShifts.AddAsync(workShift);
            await _context.SaveChangesAsync();
            return workShift.WorkShiftId;
        }

        public async Task<List<WorkShift>> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.WorkShifts
                .Include(w => w.Employee)
                .Where(w => w.WorkDate >= startDate.Date &&
                            w.WorkDate <= endDate.Date)
                .OrderBy(w => w.WorkDate)
                .ThenBy(w => w.ShiftType)
                .ThenBy(w => w.Employee.FullName)
                .ToListAsync();
        }

        public async Task<bool> DeleteAsync(int workShiftId)
        {
            var workShift = await _context.WorkShifts.FindAsync(workShiftId);
            if (workShift == null) return false;

            _context.WorkShifts.Remove(workShift);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> CheckDuplicateAsync(int employeeId, DateTime workDate, int shiftType)
        {
            return await _context.WorkShifts.AnyAsync(w =>
                w.EmployeeId == employeeId &&
                w.WorkDate == workDate.Date &&
                w.ShiftType == shiftType);
        }

        public async Task<WorkShift?> GetByIdAsync(int id)
        {
            return await _context.WorkShifts
                .Include(w => w.Employee)
                .FirstOrDefaultAsync(w => w.WorkShiftId == id);
        }
    }
}
