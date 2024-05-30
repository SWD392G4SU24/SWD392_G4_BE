using JewelrySalesSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities.Configured
{
    [Table("Counter")]
    public class Counter : ConfiguredEntity
    {
        public virtual ICollection<OrderEntity> Orders { get; set; }
    }
}
