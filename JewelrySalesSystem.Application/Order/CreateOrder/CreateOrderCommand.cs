using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.CreateOrder
{
    public class CreateOrderCommand : IRequest<string>, ICommand
    {
        public CreateOrderCommand( string note, string type, decimal totalCost, string? promotionID, int? counterID, string buyerID, int paymentMethodID)
        {
            Note = note;
            Type = type;
            TotalCost = totalCost;
            PromotionID = promotionID;
            CounterID = counterID;
            BuyerID = buyerID;
            PaymentMethodID = paymentMethodID;
        }

        public required string Note { get; set; }
        public required string Type { get; set; }
        public required decimal TotalCost { get; set; }
        public string? PromotionID { get; set; }
        public int? CounterID { get; set; }
        public required string BuyerID { get; set; }
        public required int PaymentMethodID { get; set; }
    }
}
