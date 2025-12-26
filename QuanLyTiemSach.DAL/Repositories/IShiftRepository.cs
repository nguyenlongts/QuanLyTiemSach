using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.DAL.Repositories
{
    public interface IShiftRepository
    {
        Task<int> AddAsync(WorkShift shift);
        Task<List<WorkShift>> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<WorkShift?> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int workShiftId);
        Task<bool> CheckDuplicateAsync(int employeeId, DateTime workDate, int shiftType);
    }
}