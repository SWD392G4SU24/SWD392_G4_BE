using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.ExchangePoint
{
    public class UpdateUserIDByPromotionCommand : IRequest<string>, ICommand
    {
        public UpdateUserIDByPromotionCommand(string customerID, string orderID, string voucherCode)
        {
            CustomerID = customerID;
            OrderID = orderID;
            VoucherCode = voucherCode;
        }

        public string CustomerID { get; set; }
        public string OrderID { get; set; }
        public string VoucherCode { get; set; }
        
    }

}
