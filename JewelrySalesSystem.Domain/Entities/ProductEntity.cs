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
    [Table("Product")]
    public class ProductEntity : BaseEntity
    {
        public required decimal Cost {  get; set; }
        public required float Weight {  get; set; }
        public required int Quantity { get; set; }
        public string? Description {  get; set; }
        public required int CategoryID {  get; set; }
        [ForeignKey(nameof(CategoryID))]
        public virtual CategoryEntity Category {  get; set; }
        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }
    }
}
