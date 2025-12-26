using System.Collections.Generic;
using System.Threading.Tasks;
using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.Data.Repositories
{
    public interface ISalaryRepository
    {
        /// <summary>
        /// Lấy tất cả bản ghi lương
        /// </summary>
        Task<List<Salary>> GetAllAsync();

        /// <summary>
        /// Lấy lương theo ID
        /// </summary>
        Task<Salary?> GetByIdAsync(int id);

        /// <summary>
        /// Lấy lương theo nhân viên và tháng
        /// </summary>
        Task<Salary?> GetByEmployeeAndMonthAsync(int employeeId, int month);

        /// <summary>
        /// Lấy tất cả lương của một nhân viên
        /// </summary>
        Task<List<Salary>> GetByEmployeeIdAsync(int employeeId);

        /// <summary>
        /// Lấy tất cả lương trong một tháng
        /// </summary>
        Task<List<Salary>> GetByMonthAsync(int month);

        /// <summary>
        /// Thêm bản ghi lương mới
        /// </summary>
        Task AddAsync(Salary salary);

        /// <summary>
        /// Cập nhật bản ghi lương
        /// </summary>
        Task UpdateAsync(Salary salary);

        /// <summary>
        /// Xóa bản ghi lương
        /// </summary>
        Task DeleteAsync(Salary salary);

        /// <summary>
        /// Kiểm tra xem lương đã tồn tại chưa
        /// </summary>
        Task<bool> ExistsAsync(int employeeId, int month);

        /// <summary>
        /// Lưu thay đổi vào database
        /// </summary>
        Task SaveChangesAsync();
    }
}
