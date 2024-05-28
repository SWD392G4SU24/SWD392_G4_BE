using JewelrySalesSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities
{
    [Table("OrderDetail")]
    public class OrderDetailEntity : BaseEntity
    {
        public required Guid OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public virtual OrderEntity Order {  get; set; }
        public required Guid SanPhamID { get; set; }
        [ForeignKey(nameof(SanPhamID))]
        public virtual ProductEntity SanPham { get; set; }
    }
}
