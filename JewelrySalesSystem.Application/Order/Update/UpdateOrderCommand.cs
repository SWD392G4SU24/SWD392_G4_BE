using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<string>, ICommand
    {
        public UpdateOrderCommand(string id, string note, OrderType type, decimal totalCost, string? promotionID, int? counterID, string buyerID, int paymentMethodID)
        {
            Id = id;
            Note = note;
            Type = type;
            TotalCost = totalCost;
            PromotionID = promotionID;
            CounterID = counterID;
            BuyerID = buyerID;
            PaymentMethodID = paymentMethodID;
        }
        public string Id { get; set; }
        public required string Note { get; set; }
        public required OrderType Type { get; set; }
        public required decimal TotalCost { get; set; }
        public string? PromotionID { get; set; }
        public int? CounterID { get; set; }
        public required string BuyerID { get; set; }
        public required int PaymentMethodID { get; set; }
    }
}
