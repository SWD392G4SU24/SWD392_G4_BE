using JewelrySalesSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities.Configured
{
    [Table("Diamond")]
    public class DiamondEntity : ConfiguredEntity
    {
        public required decimal BuyCost {  get; set; }
        public required decimal SellCost { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }

    }
}
