using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.Domain.Model
{
        [Table("Categories")]
        public class Category
        {
            [Key]
            public int Id { get; set; }

            [Required]
            [MaxLength(100)]
            public string Name { get; set; }

            [MaxLength(500)]
            public string Description { get; set; }

            // Navigation Property
            public virtual ICollection<Book> Books { get; set; }

            public Category()
            {
                Books = new HashSet<Book>();
            }

            public Category(int id, string name, string description)
            {
                Id = id;
                Name = name;
                Description = description;
                Books = new HashSet<Book>();
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

            public override string ToString()
            {
                return Name;
            }
        }
    }
