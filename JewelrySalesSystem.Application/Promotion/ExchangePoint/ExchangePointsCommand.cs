using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.ExchangePoint
{
    public class ExchangePointsCommand : IRequest<string>, ICommand
    {
        public ExchangePointsCommand(string customerID, string voucherCode)
        {
            CustomerID = customerID;
            VoucherCode = voucherCode;
        }

        public string CustomerID { get; set; }
        public string VoucherCode { get; set; }
        
    }

}
