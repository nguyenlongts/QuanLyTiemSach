using System.Collections.Generic;
using System.Threading.Tasks;
using QuanLyTiemSach.Domain.Model;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.BLL.Services.Interfaces
{
    public interface ISalaryService
    {
        Task<List<Employee>> GetAllEmployeesAsync();

        Task<int> GetShiftCountByMonthAsync(int employeeId, int month, int year);

        decimal CalculateSalary(int shifts);

        Task<List<Salary>> GetAllSalariesAsync();
        Task<Salary?> GetSalaryByIdAsync(int id);
        Task<Salary?> GetSalaryByEmployeeAndMonthAsync(int employeeId, int month);
        Task<List<Salary>> GetSalariesByEmployeeAsync(int employeeId);
        Task<List<Salary>> GetSalariesByMonthAsync(int month);

        Task<(bool success, string message)> CreateOrUpdateSalaryAsync(
            int employeeId, int month, int year
        );

        Task<(bool success, string message)> DeleteSalaryAsync(int id);

        Task<bool> IsSalaryExistsAsync(int employeeId, int month);
    }
}
