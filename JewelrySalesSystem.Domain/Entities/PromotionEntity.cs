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
    [Table("Promotion")]
    public class PromotionEntity : BaseEntity
    {
        public string? Description {  get; set; }
        public required PromotionStatus Status { get; set; }
        public required decimal ConditionsOfUse {  get; set; }
        public required float ReducedPercent {  get; set; }
        public required decimal MaximumReduce {  get; set; }
        public required int ExchangePoint {  get; set; }
        public required DateTime ExpiresTime {  get; set; }

        public string? UserID {  get; set; }
        [ForeignKey(nameof(UserID))]
        public virtual UserEntity? User { get; set; }

        public string? OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public virtual OrderEntity? Order { get; set; }
    }
}
