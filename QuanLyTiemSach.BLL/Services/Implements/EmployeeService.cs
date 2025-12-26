using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.BLL.Services.Implements
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                return await _employeeRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên.", ex);
            }
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            if (id <= 0)
                throw new Exception("ID không hợp lệ.");

            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<bool> CreateEmployeeAsync(Employee employee)
        {
            if (employee == null)
                throw new Exception("Dữ liệu nhân viên không hợp lệ.");

            if (string.IsNullOrWhiteSpace(employee.FullName))
                throw new Exception("Tên nhân viên không được để trống.");

            employee.EmployeeCode = await GenerateEmployeeCodeAsync();
            employee.CreatedAt = DateTime.Now;
            employee.IsActive = true;

            await _employeeRepository.AddAsync(employee);
            return true;
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            if (employee == null)
                throw new Exception("Dữ liệu nhân viên không hợp lệ.");

            if (!await _employeeRepository.ExistsAsync(employee.EmployeeId))
                throw new Exception("Nhân viên không tồn tại.");

            await _employeeRepository.UpdateAsync(employee);
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(int id)
        {
            if (id <= 0)
                throw new Exception("ID không hợp lệ.");

            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
                throw new Exception("Nhân viên không tồn tại.");

            await _employeeRepository.DeleteAsync(employee);
            return true;
        }

        public async Task<bool> EmployeeExistsAsync(int id)
        {
            return await _employeeRepository.ExistsAsync(id);
        }


        private async Task<string> GenerateEmployeeCodeAsync()
        {
            int count = await _employeeRepository.CountAsync();
            int next = count + 1;
            return $"NV{next:D3}";
        }
    }
}
