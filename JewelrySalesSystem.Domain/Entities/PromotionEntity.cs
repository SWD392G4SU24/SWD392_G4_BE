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
    [Table("Promotion")]
    public class PromotionEntity : BaseEntity
    {
        public required decimal ConditionsOfUse {  get; set; }
        public required float ReducedPercent {  get; set; }
        public required decimal MaximumReduce {  get; set; }
        public required int ExchangePoint {  get; set; }
        public required DateTime ExpiresTime {  get; set; }
        public virtual ICollection<CategoryEntity> Categories { get; set;}
        public virtual ICollection<OrderEntity> Orders { get; set;}
        public virtual ICollection<UsersEntity> Users { get; set;}
    }
}
