using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.ExchangeVoucher
{
    public class ExchangeVoucherCommand : IRequest<string>, IQuery
    {

        public ExchangeVoucherCommand(string voucherContent)
        {
            VoucherContent = voucherContent;
        }

        public string VoucherContent { get; set; }
    }
}
