using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShiftManagement.Models;

namespace QuanLyTiemSach.DAL.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        int Add(Employee employee);
        bool Update(Employee employee);
        bool Delete(int id);
        bool Exists(int id);
    }
}
