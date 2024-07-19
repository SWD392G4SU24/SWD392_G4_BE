using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.ConfirmPickedOrder
{
    public class ConfirmPickedOrderCommand : IRequest<string>, ICommand
    {
        public ConfirmPickedOrderCommand(string orderID)
        {
            OrderID = orderID;
        }
        public string OrderID { get; set; }
    }
}
