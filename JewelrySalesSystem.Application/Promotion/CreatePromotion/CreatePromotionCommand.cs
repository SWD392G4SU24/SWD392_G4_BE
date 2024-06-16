
using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
namespace JewelrySalesSystem.Application.Promotion.CreatePromotion
{
    public class CreatePromotionCommand : IRequest<string>, ICommand
    {
        public CreatePromotionCommand(decimal conditionsOfUse, float reducedPercent, decimal maximumReduce, int exchangePoint, DateTime expiresTime)
        {
            ConditionsOfUse = conditionsOfUse;
            ReducedPercent = reducedPercent;
            MaximumReduce = maximumReduce;
            ExchangePoint = exchangePoint;
            ExpiresTime = expiresTime;
        }
        public string? Description { get; set; }
        public  decimal ConditionsOfUse { get; set; }
        public  float ReducedPercent { get; set; }
        public  decimal MaximumReduce { get; set; }
        public  int ExchangePoint { get; set; }
        public  DateTime ExpiresTime { get; set; }

    }

}
