
using QuanLyTiemSach.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.DAL.Repositories
{

    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
        Task<List<User>> SearchAsync(string keyword);
        Task<User?> LoginAsync(string username, string password);

        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string email);

    }

}
