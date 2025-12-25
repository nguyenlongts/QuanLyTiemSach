using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(int id);
        bool CreateEmployee(Employee employee, out string message);
        bool UpdateEmployee(Employee employee, out string message);
        bool DeleteEmployee(int id, out string message);
        bool EmployeeExists(int id);
    }
}
