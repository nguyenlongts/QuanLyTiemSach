using System.Collections.Generic;
using QuanLyTiemSach.Domain.Model;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.BLL.Services.Interfaces
{
    public interface ISalaryService
    {
        List<Employee> GetAllEmployees();
        int GetShiftCountByMonth(int employeeId, int month, int year);
        decimal CalculateSalary(int shifts);
        List<Salary> GetAllSalaries();
        Salary GetSalaryById(int id);
        Salary GetSalaryByEmployeeAndMonth(int employeeId, int month);
        List<Salary> GetSalariesByEmployee(int employeeId);
        List<Salary> GetSalariesByMonth(int month);
        bool CreateOrUpdateSalary(int employeeId, int month, int year, out string message);
        bool DeleteSalary(int id, out string message);
        bool IsSalaryExists(int employeeId, int month);
    }
}