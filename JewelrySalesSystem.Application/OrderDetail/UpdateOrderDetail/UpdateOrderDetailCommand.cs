using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.UpdateOrderDetail
{
    public class UpdateOrderDetailCommand : IRequest<string>, ICommand
    {
        public UpdateOrderDetailCommand(string productID, int quantity)
        {
            ProductID = productID;
            Quantity = quantity;
        }
        public string ProductID { get; set; }
        public int Quantity { get; set; }

    }
}
