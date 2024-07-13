using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.AfterPayment
{
    public class UpdatePaymentSuccessOrderCommand : IRequest<string>, ICommand
    {
        public UpdatePaymentSuccessOrderCommand(string id)
        {
            ID = id;
        }
        public string ID { get; set; }
    }
}
