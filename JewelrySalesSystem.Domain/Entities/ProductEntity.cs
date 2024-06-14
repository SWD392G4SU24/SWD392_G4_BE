using JewelrySalesSystem.Domain.Entities.Base;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections;
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
        public required decimal WageCost {  get; set; }
        public float? GoldWeight {  get; set; }
        //Product: vàng thuần, kc thuần, vàng đính kc -> tùy theo đó để tính giá sản phẩm
        public int? GoldType {  get; set; }
        [ForeignKey(nameof(GoldType))]
        public virtual GoldEntity? Gold { get; set; }
        public int? DiamonType { get; set; }
        [ForeignKey(nameof(DiamonType))]
        public virtual DiamonEntity? Diamon { get; set; }
        public string? ImageURL { get; set; }
        public required int Quantity { get; set; }
        public string? Description {  get; set; }       
        public required int CategoryID {  get; set; }
        [ForeignKey(nameof(CategoryID))]
        public virtual CategoryEntity Category {  get; set; }
        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }
    }
}
