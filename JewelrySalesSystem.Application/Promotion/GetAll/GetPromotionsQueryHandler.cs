using JewelrySalesSystem.Application.Promotion.GetAll;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetPromotion
{
    public class GetAllPromotionsQueryHandler : IRequestHandler<GetPromotionsQuery, IEnumerable<PromotionDto>>

    {
        private readonly IPromotionRepository _promotionRepository;
        public GetAllPromotionsQueryHandler(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }
        public async Task<IEnumerable<PromotionDto>> Handle(GetPromotionsQuery request, CancellationToken cancellationToken)
        {
            // Logic to retrieve promotions base on query parameters(if any)
            var promotions = await _promotionRepository.FindAllAsync(cancellationToken);
            return promotions.Select(s => new PromotionDto
            {
                Id = s.ID,
                ConditionsOfUse = s.ConditionsOfUse,
                ExchangePoint = s.ExchangePoint,
                ExpiresTime = s.ExpiresTime,
                MaximumReduce = s.MaximumReduce,
                ReducedPercent = s.ReducedPercent,
                UserID = s.UserID
            }).ToList();
        }

       
    }
}
