using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.CreatePaymentMethod
{
    public class CreatePaymentMethodCommand : IRequest<string>, ICommand
    {
        public CreatePaymentMethodCommand(string name)
        {
            Name = name;
        }
        public required string Name { get; set; }
    }
}
