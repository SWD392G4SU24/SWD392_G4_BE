using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Entities.VnPayModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.VnPay.CreatePaymentUrl
{
    public class CreatePaymentUrlCommand : IRequest<string>, ICommand
    {
        public PaymentInformationModel Model { get; }
        public HttpContext Context { get; }

        public CreatePaymentUrlCommand(PaymentInformationModel model, HttpContext context)
        {
            Model = model;
            Context = context;
        }
    }
}
