using AutoMapper;
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
    public class GetAllPromotionsQueryHandler : IRequestHandler<GetPromotionsQuery, List<PromotionDto>>

    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        public GetAllPromotionsQueryHandler(IPromotionRepository promotionRepository,IMapper mapper )
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }
        public async Task<List<PromotionDto>> Handle(GetPromotionsQuery request, CancellationToken cancellationToken)
        {
            // Logic to retrieve promotions base on query parameters(if any)
            var promotions = await _promotionRepository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
            return promotions.MapToPromotionDtoList(_mapper);
        }
    }
}
