using AutoMapper;
using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Promotion.GetPromotion;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetById
{
    public class GetPromotionByIDQueryHandler : IRequestHandler<GetByPromotionIDQuery, PromotionDto>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        public GetPromotionByIDQueryHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }
        public async Task<PromotionDto> Handle(GetByPromotionIDQuery request, CancellationToken cancellationToken)
        {
            // Logic to retrieve promotions base on query parameters(if any)
            var promotion = await _promotionRepository.FindAsync(s => s.ID == request.Id && s.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Promotion không tồn tại");
            return promotion.MapToPromotionDto(_mapper);
        }
    }
}
