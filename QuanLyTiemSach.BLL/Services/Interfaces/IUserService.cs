using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<List<User>> SearchAsync(string keyword);
        Task<User?> LoginAsync(string username, string password);
    }
}
