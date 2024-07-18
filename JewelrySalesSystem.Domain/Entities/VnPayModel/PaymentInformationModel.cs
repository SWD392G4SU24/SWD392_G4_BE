using JewelrySalesSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities.VnPayModel
{
    //[Table("Payment")]
    [NotMapped]
    public class PaymentInformationModel //: BaseEntity
    {
        public string OrderType { get; set; }
        public double Amount { get; set; }
    }
}
