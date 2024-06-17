using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.UpdatePromotion
{
    public class UpdatePromotionCommand : IRequest<string>
    {
        public UpdatePromotionCommand(string id, string? description, decimal conditionsOfUse, float reducedPercent, decimal maximumReduce, int exchangePoint, DateTime expiresTime)
        {
            ID = id;
            Description = description;
            ConditionsOfUse = conditionsOfUse;
            ReducedPercent = reducedPercent;
            MaximumReduce = maximumReduce;
            ExchangePoint = exchangePoint;
            ExpiresTime = expiresTime;
        }

        public string ID { get; set; }
        public string? Description { get; set; }
        public decimal ConditionsOfUse { get; set; }
        public float ReducedPercent { get; set; }
        public decimal MaximumReduce { get; set; }
        public int ExchangePoint { get; set; }
        public DateTime ExpiresTime { get; set; }
    }
}
