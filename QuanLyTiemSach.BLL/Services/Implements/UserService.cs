using QuanLyTiemSach.BLL.Services.Interfaces;
using QuanLyTiemSach.DAL;
using QuanLyTiemSach.DAL.Repositories;

using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.BLL.Services.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly BookStoreDbContext _context;


        public UserService(
       IUserRepository userRepository,
       IEmployeeRepository employeeRepository,
       BookStoreDbContext context)
        {
            _userRepository = userRepository;
            _employeeRepository = employeeRepository;
            _context = context;
        }


        public async Task<List<User>> GetAllAsync()
        {
            try
            {
                return await _userRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể tải danh sách người dùng.", ex);
            }
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("ID không hợp lệ.");

                return await _userRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Không thể lấy thông tin người dùng.", ex);
            }
        }

        public async Task AddAsync(User user, string employeePhone)
        {
            using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                user.CreatedDate = DateTime.Now;
                user.Status ??= "Active";

                await _userRepository.AddAsync(user);
                await _context.SaveChangesAsync();

                if (user.Role == "Staff")
                {
                    if (string.IsNullOrWhiteSpace(employeePhone))
                        throw new Exception("Nhân viên phải có số điện thoại.");

                    var employee = new Employee
                    {
                        UserId = user.UserID,
                        FullName= user.FullName,
                        EmployeeCode = await GenerateEmployeeCodeAsync(),
                        PhoneNumber = employeePhone,
                        CreatedAt = DateTime.Now,
                        IsActive = true
                    };

                    await _employeeRepository.AddAsync(employee);
                    await _context.SaveChangesAsync();
                }

                await tx.CommitAsync();
            }
            catch (Exception ex)
            {
                var inner = ex.InnerException?.Message;
                throw new Exception($"Lỗi khi lưu dữ liệu: {inner}", ex);
            }

        }


        public async Task UpdateAsync(User user)
        {
            try
            {
                if (user == null)
                    throw new Exception("Dữ liệu người dùng không hợp lệ.");

                var existingUser =
                    await _userRepository.GetByIdAsync(user.UserID);

                if (existingUser == null)
                    throw new Exception("Người dùng không tồn tại.");

                if (!string.Equals(existingUser.Username, user.Username,
                    StringComparison.OrdinalIgnoreCase))
                {
                    var u =
                        await _userRepository.GetByUsernameAsync(user.Username);
                    if (u != null)
                        throw new Exception("Tên đăng nhập đã tồn tại.");
                }

                if (!string.Equals(existingUser.Email, user.Email,
                    StringComparison.OrdinalIgnoreCase))
                {
                    var e =
                        await _userRepository.GetByEmailAsync(user.Email);
                    if (e != null)
                        throw new Exception("Email đã được sử dụng.");
                }

                existingUser.Username = user.Username?.Trim();
                existingUser.FullName = user.FullName?.Trim();
                existingUser.Email = user.Email?.Trim();
                existingUser.Role = user.Role;
                existingUser.Status = user.Status;

                if (!string.IsNullOrWhiteSpace(user.Password))
                {
                    existingUser.Password = user.Password;
                }

                await _userRepository.UpdateAsync(existingUser);
            }
            catch (Exception ex)
            {
                throw new Exception("Cập nhật người dùng thất bại: " + ex.Message, ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("ID không hợp lệ.");

                var user = await _userRepository.GetByIdAsync(id);
                if (user == null)
                    throw new Exception("Người dùng không tồn tại.");

                await _userRepository.DeleteAsync(user);
            }
            catch (Exception ex)
            {
                throw new Exception("Xóa người dùng thất bại: " + ex.Message, ex);
            }
        }

        public async Task<List<User>> SearchAsync(string keyword)
        {
            try
            {
                keyword = keyword?.Trim() ?? string.Empty;
                return await _userRepository.SearchAsync(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Tìm kiếm người dùng thất bại.", ex);
            }
        }

        public async Task<User?> LoginAsync(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new Exception("Vui lòng nhập tên đăng nhập.");

            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Vui lòng nhập mật khẩu.");

            try
            {
                var user = await _userRepository.LoginAsync(
                    username.Trim(),
                    password
                );

                if (user == null)
                    throw new Exception("Sai tài khoản hoặc mật khẩu.");

                if (!string.Equals(user.Status, "Active", StringComparison.OrdinalIgnoreCase))
                    throw new Exception("Tài khoản đã bị khóa.");

                return user;
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    throw;

                throw new Exception("Lỗi.", ex);
            }
        }
        private async Task<string> GenerateEmployeeCodeAsync()
        {
            int count = await _employeeRepository.CountAsync();
            int nextNumber = count + 1;

            return $"NV{nextNumber:D3}";
        }

    }
}
