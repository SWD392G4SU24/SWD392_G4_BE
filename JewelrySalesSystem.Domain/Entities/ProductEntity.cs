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
        public string? GoldType {  get; set; } //API BTMC
        public string? DiamonType { get; set; } //3ly6 4ly1 4ly5 5ly4 6ly 6ly3 6ly8 7ly2 8ly1 9ly
        public string? ImageURL { get; set; }
        public required int Quantity { get; set; }
        public string? Description {  get; set; }       
        public required int CategoryID {  get; set; }
        [ForeignKey(nameof(CategoryID))]
        public virtual CategoryEntity Category {  get; set; }
        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }
    }
}
