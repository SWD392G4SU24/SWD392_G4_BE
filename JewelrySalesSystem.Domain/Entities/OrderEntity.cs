using JewelrySalesSystem.Domain.Entities.Base;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Domain.Entities
{
    [Table("Order")]
    public class OrderEntity : BaseEntity
    {
        public required string Note {  get; set; }
        public required OrderType Type { get; set; }
        public required OrderStatus Status { get; set; }
        public required decimal TotalCost {  get; set; }

        public string? PromotionID { get; set; }
        [ForeignKey(nameof(PromotionID))]
        public virtual PromotionEntity? Promotion { get; set; }

        public int? CounterID { get; set; }
        [ForeignKey(nameof(CounterID))]
        public virtual CounterEntity? Counter { get; set; }

        public required string BuyerID { get; set; }
        [ForeignKey(nameof(BuyerID))]
        public virtual UserEntity User { get; set; }

        public required int PaymentMethodID { get; set; }
        [ForeignKey(nameof(PaymentMethodID))]
        public virtual PaymentMethodEntity PaymentMethod { get; set; }

        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }
    }
}
