using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShiftManagement.Models;
using WorkShiftManagement.Repositories;

namespace QuanLyTiemSach.BLL.Services.Implements
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAllEmployees()
        {
            try
            {
                return _employeeRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy danh sách nhân viên: {ex.Message}", ex);
            }
        }

        public Employee GetEmployeeById(int id)
        {
            try
            {
                return _employeeRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi lấy thông tin nhân viên: {ex.Message}", ex);
            }
        }

        public bool CreateEmployee(Employee employee, out string message)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(employee.FullName))
                {
                    message = "Tên nhân viên không được để trống!";
                    return false;
                }

                _employeeRepository.Add(employee);
                message = "Thêm nhân viên thành công!";
                return true;
            }
            catch (Exception ex)
            {
                message = $"Lỗi: {ex.Message}";
                return false;
            }
        }

        public bool UpdateEmployee(Employee employee, out string message)
        {
            try
            {
                if (!_employeeRepository.Exists(employee.EmployeeId))
                {
                    message = "Nhân viên không tồn tại!";
                    return false;
                }

                _employeeRepository.Update(employee);
                message = "Cập nhật nhân viên thành công!";
                return true;
            }
            catch (Exception ex)
            {
                message = $"Lỗi: {ex.Message}";
                return false;
            }
        }

        public bool DeleteEmployee(int id, out string message)
        {
            try
            {
                if (!_employeeRepository.Exists(id))
                {
                    message = "Nhân viên không tồn tại!";
                    return false;
                }

                _employeeRepository.Delete(id);
                message = "Xóa nhân viên thành công!";
                return true;
            }
            catch (Exception ex)
            {
                message = $"Lỗi: {ex.Message}";
                return false;
            }
        }

        public bool EmployeeExists(int id)
        {
            return _employeeRepository.Exists(id);
        }
    }
}
