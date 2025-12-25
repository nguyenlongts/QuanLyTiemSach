using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemSach.Domain.Model
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(Book))]
        public string BookID { get; set; }
        public Book Book { get; set; }

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

}
