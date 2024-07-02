using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.NewFolder
{
    public class CreatePromotionByQuantityCommand : IRequest<List<string>>, ICommand
    {
        public CreatePromotionByQuantityCommand(int quantity, string? description, decimal conditionsOfUse, float reducedPercent, decimal maximumReduce, int exchangePoint, DateTime expiresTime, string? userID)
        {
            Quantity = quantity;
            Description = description;
            ConditionsOfUse = conditionsOfUse;
            ReducedPercent = reducedPercent;
            MaximumReduce = maximumReduce;
            ExchangePoint = exchangePoint;
            ExpiresTime = expiresTime;
            UserID = userID;
        }

        public required int Quantity { get; set; }
        public string? Description { get; set; }
        public decimal ConditionsOfUse { get; set; }
        public float ReducedPercent { get; set; }
        public decimal MaximumReduce { get; set; }
        public int ExchangePoint { get; set; }
        public DateTime ExpiresTime { get; set; }
        public string? UserID { get; set; }
        
 
    }
}
