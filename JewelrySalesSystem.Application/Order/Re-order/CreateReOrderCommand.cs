using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.Re_order
{
    public class CreateReOrderCommand : IRequest<string>, ICommand
    {
        public CreateReOrderCommand(string? orderDetailID, int? quantity, string customerID, string? goldType, float? goldWeight)
        {
            OrderDetailID = orderDetailID;
            Quantity = quantity;
            CustomerID = customerID;
            GoldType = goldType;
            GoldWeight = goldWeight;
        }

        public string? OrderDetailID { get; set; }
        public int? Quantity {  get; set; }
        public string CustomerID { get; set; }
        public string? GoldType { get; set; }
        public float? GoldWeight { get; set; }
    }
}
