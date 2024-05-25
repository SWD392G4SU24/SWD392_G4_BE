using JewelrySalesSystem.Domain.Entities.Base;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities
{
    [Table("Order")]
    public class OrderEntity : BaseEntity
    {
        public required string GhiChu {  get; set; }
        public int? QuayBanID { get; set; }
        [ForeignKey(nameof(QuayBanID))]
        public virtual QuanBanEntity QuayBan { get; set; }
        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }
    }
}
