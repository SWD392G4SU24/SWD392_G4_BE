using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Promotion.GetPromotion;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIDQuery, IEnumerable<PromotionDto>>
    {
        private readonly IPromotionRepository _promotionRepository;
        public GetByIdQueryHandler(IPromotionRepository promotionRepository)
        {
            _promotionRepository = promotionRepository;
        }
        public async Task<IEnumerable<PromotionDto>> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            // Logic to retrieve promotions base on query parameters(if any)
            var promotions = await _promotionRepository.GetPromotionByIdAsnyc(request.Id, cancellationToken);
            if (promotions is null) throw new NotFoundException("VoucherCode is not exist");
            return (IEnumerable<PromotionDto>)promotions;
        }
    }
}
