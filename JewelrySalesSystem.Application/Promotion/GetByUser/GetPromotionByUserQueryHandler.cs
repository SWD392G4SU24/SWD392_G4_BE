using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetByUser
{
    public class GetPromotionByUserQueryHandler : IRequestHandler<GetPromotionByUserQuery, List<PromotionByUserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetPromotionByUserQueryHandler(IUserRepository userRepository, IPromotionRepository promotionRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<List<PromotionByUserDto>> Handle(GetPromotionByUserQuery request, CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
            if (!promotion.Any()) throw new NotFoundException("Không tìm thấy promtion nào");
            //promotion.MapToPromotionDtoList(_mapper);
            var user = await _userRepository.FindAsync(x=> x.ID == request.UserId && x.DeletedAt == null, cancellationToken)
            ?? throw new NotFoundException("User không tồn tại");
            return promotion.MapToPromotionByUserDtoList(_mapper);
            
        }
    }
}
