using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.Domain.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category()
        {
        }
        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public bool IsValid(out string msg)
        {
            msg = string.Empty;
            if (string.IsNullOrWhiteSpace(Name))
            {
                msg = "Chưa nhập tên thể loại";
                return false;
            }
            if (string.IsNullOrWhiteSpace(Description))
            {
                msg = "Chưa nhập mô tả thể loại";
                return false;
            }
            return true;
        }

    }
}
