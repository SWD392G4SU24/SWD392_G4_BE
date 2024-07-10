using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.Delete
{
    public class DeletePaymentMethodCommand : IRequest<string>, ICommand
    {
        public DeletePaymentMethodCommand(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
