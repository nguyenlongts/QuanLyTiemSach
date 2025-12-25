using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuanLyTiemSach.DAL;
//using WorkShiftManagement.Data;
using WorkShiftManagement.Models;

namespace WorkShiftManagement.Repositories
{
    public class WorkShiftRepository
    {
        private readonly BookStoreDbContext _context;

        public WorkShiftRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public int Add(WorkShift workShift)
        {
            _context.WorkShifts.Add(workShift);
            _context.SaveChanges();
            return workShift.WorkShiftId;
        }

        public List<WorkShift> GetByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.WorkShifts
                .Include(w => w.Employee)
                .Where(w => w.WorkDate >= startDate && w.WorkDate <= endDate)
                .OrderBy(w => w.WorkDate)
                .ThenBy(w => w.ShiftType)
                .ThenBy(w => w.Employee.FullName)
                .ToList();
        }

        public bool Delete(int workShiftId)
        {
            var workShift = _context.WorkShifts.Find(workShiftId);
            if (workShift != null)
            {
                _context.WorkShifts.Remove(workShift);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool CheckDuplicate(int employeeId, DateTime workDate, int shiftType)
        {
            return _context.WorkShifts.Any(w =>
                w.EmployeeId == employeeId &&
                w.WorkDate == workDate.Date &&
                w.ShiftType == shiftType);
        }

        public WorkShift GetById(int id)
        {
            return _context.WorkShifts
                .Include(w => w.Employee)
                .FirstOrDefault(w => w.WorkShiftId == id);
        }
    }
}