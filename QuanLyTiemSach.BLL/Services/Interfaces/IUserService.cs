using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.BLL.Services.Interfaces
{
    public interface IUserService
    {
        User? Login(string username, string password);
        List<User> Search(string keyword);
        void Delete(int id);
        void Update(User user);
        void Add(User user);
        User? GetById(int id);
        List<User> GetAll();
    }
}
