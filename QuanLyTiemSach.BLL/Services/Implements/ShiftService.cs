using QuanLyTiemSach.DAL;
using System;
using System.Collections.Generic;

//using WorkShiftManagement.Data;
using WorkShiftManagement.Models;
using WorkShiftManagement.Repositories;

namespace QuanLyTiemSach.BLL.Services.Implements
{
    public class WorkShiftService
    {
        private readonly WorkShiftRepository _workShiftRepo;
        private readonly EmployeeRepository _employeeRepo;

        public WorkShiftService(BookStoreDbContext context)
        {
            _workShiftRepo = new WorkShiftRepository(context);
            _employeeRepo = new EmployeeRepository(context);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepo.GetAll();
        }

        public string AddWorkShift(int employeeId, DateTime workDate, int shiftType, string note)
        {
            // Validate
            var employee = _employeeRepo.GetById(employeeId);
            if (employee == null)
            {
                return "Nhân viên không tồn tại!";
            }

            if (shiftType < 1 || shiftType > 4)
            {
                return "Ca làm việc không hợp lệ!";
            }

            // Check duplicate
            if (_workShiftRepo.CheckDuplicate(employeeId, workDate, shiftType))
            {
                return "Nhân viên đã được phân ca này rồi!";
            }

            var workShift = new WorkShift
            {
                EmployeeId = employeeId,
                WorkDate = workDate,
                ShiftType = shiftType,
                Note = note,
                CreatedAt = DateTime.Now
            };

            int id = _workShiftRepo.Add(workShift);
            return id > 0 ? null : "Thêm ca làm thất bại!";
        }

        public List<WorkShift> GetWorkShiftsByWeek(DateTime startDate)
        {
            DateTime endDate = startDate.AddDays(6);
            return _workShiftRepo.GetByDateRange(startDate, endDate);
        }

        public bool DeleteWorkShift(int workShiftId)
        {
            return _workShiftRepo.Delete(workShiftId);
        }
    }
}