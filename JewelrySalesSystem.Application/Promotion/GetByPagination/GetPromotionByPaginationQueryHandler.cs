using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelrySalesSystem.Domain.Repositories;

namespace JewelrySalesSystem.Application.Promotion.GetByPagination
{
    public class GetPromotionByPaginationQueryHandler : IRequestHandler<GetPromotionByPaginationQuery, PagedResult<PromotionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IPromotionRepository _promotionRepository;

        public GetPromotionByPaginationQueryHandler(IMapper mapper, IPromotionRepository promotionRepository)
        {
            _mapper = mapper;
            _promotionRepository = promotionRepository;
        }

        public async Task<PagedResult<PromotionDto>> Handle(GetPromotionByPaginationQuery query, CancellationToken cancellationToken)
        {
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
