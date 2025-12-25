using QuanLyTiemSach.DAL;
using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly BookStoreDbContext _context;

        public UserService()
        {
            _context = new BookStoreDbContext();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserID == id);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<User> Search(string keyword)
        {
            return _context.Users
                .Where(x =>
                    x.Username.Contains(keyword) ||
                    x.FullName.Contains(keyword) ||
                    x.Email.Contains(keyword))
                .ToList();
        }

        public User? Login(string username, string password)
        {
            return _context.Users.FirstOrDefault(u =>
                 u.Username == username &&
                 u.Password == password &&
                 u.Status == "Active"
             );
        }
    }
}
