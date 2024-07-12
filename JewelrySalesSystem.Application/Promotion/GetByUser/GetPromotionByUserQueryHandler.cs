using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JewelrySalesSystem.Application.Promotion.GetByUser
{
    public class GetPromotionByUserQueryHandler : IRequestHandler<GetPromotionByUserQuery, PagedResult<PromotionDto>>
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

        public async Task<PagedResult<PromotionDto>> Handle(GetPromotionByUserQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.ID == query.UserId && x.DeletedAt == null, cancellationToken)
           ?? throw new NotFoundException("User không tồn tại");
            var promotionList = await _promotionRepository.FindAsync(x => x.UserID == query.UserId, cancellationToken)
            ?? throw new NotFoundException("Không tìm thấy promtion nào với UserID:" + query.UserId);
            var list = await _promotionRepository.FindAllAsync(x => x.DeletedAt == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<PromotionDto>.Create
            (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToPromotionDtoList(_mapper)
                );
        }
    }
}
