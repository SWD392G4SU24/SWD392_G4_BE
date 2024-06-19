using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.VnPay.PaymentCallback
{
    public class PaymentCallbackQuery : IRequest<PaymentResponseModel>, IQuery
    {
        public IQueryCollection Collections { get; set; }

        public PaymentCallbackQuery(IQueryCollection collections)
        {
            Collections = collections;
        }
    }
}
