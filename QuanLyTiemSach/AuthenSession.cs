using QuanLyTiemSach.Domain.Enums;
using QuanLyTiemSach.Domain.Model;

namespace QuanLyTiemSach.APP
{
    public static class AuthenSession
    {
        public static User? CurrentUser { get; set; }

        public static bool IsAdmin =>
            CurrentUser != null && CurrentUser.Role == UserRole.Admin.ToString();
    }
}
