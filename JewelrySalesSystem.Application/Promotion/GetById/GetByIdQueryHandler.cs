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
    public class GetByIdQueryHandler : IRequestHandler<GetByIDQuery, PromotionDto>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;
        public GetByIdQueryHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }
        public async Task<PromotionDto> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            // Logic to retrieve promotions base on query parameters(if any)
            var promotion = await _promotionRepository.FindAsync(s => s.ID == request.Id, cancellationToken)
                ?? throw new NotFoundException("Promotion không tồn tại");
            return promotion.MapToPromotionDto(_mapper);
        }
    }
}
