using System.Collections.Generic;
using QuanLyTiemSach.Domain.Model;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.Business.Services
{
    public interface ISalaryService
    {
        //List<Employee> GetAllEmployees();
        /// <summary>
        /// Tính lương dựa trên số ca làm
        /// </summary>
        decimal CalculateSalary(int shifts);

        /// <summary>
        /// Lấy tất cả bản ghi lương
        /// </summary>
        List<Salary> GetAllSalaries();

        /// <summary>
        /// Lấy lương theo ID
        /// </summary>
        Salary GetSalaryById(int id);

        /// <summary>
        /// Lấy lương theo nhân viên và tháng
        /// </summary>
        Salary GetSalaryByEmployeeAndMonth(int employeeId, int month);

        /// <summary>
        /// Lấy tất cả lương của một nhân viên
        /// </summary>
        List<Salary> GetSalariesByEmployee(int employeeId);

        /// <summary>
        /// Lấy tất cả lương trong một tháng
        /// </summary>
        List<Salary> GetSalariesByMonth(int month);

        /// <summary>
        /// Tạo hoặc cập nhật lương
        /// </summary>
        bool CreateOrUpdateSalary(int employeeId, int month, int shifts, out string message);

        /// <summary>
        /// Xóa bản ghi lương
        /// </summary>
        bool DeleteSalary(int id, out string message);

        /// <summary>
        /// Kiểm tra xem lương đã tồn tại chưa
        /// </summary>
        bool IsSalaryExists(int employeeId, int month);
    }
}