using AutoMapper;
using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Models;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Promotion.GetByDesciption;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JewelrySalesSystem.Application.Promotion.GetPromotionQuantity
{
    public class FilterPromotionQueryHandler : IRequestHandler<FilterPromotionQuery, PagedResult<PromotionQuantityDto>>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public FilterPromotionQueryHandler(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PromotionQuantityDto>> Handle(FilterPromotionQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<PromotionEntity>, IQueryable<PromotionEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.DeletedAt == null && x.UserID == null);
                if (!string.IsNullOrEmpty(request.VoucherContent))
                {
                    query = query.Where(x => x.Description.Contains(request.VoucherContent));
                }
                if (request.ReducedPercent.HasValue)
                {
                    query = query.Where(x => x.ReducedPercent == request.ReducedPercent.Value);
                }
                if (request.ConditionsOfUse.HasValue)
                {
                    query = query.Where(x => x.ConditionsOfUse == request.ConditionsOfUse.Value);
                }
                if (request.MaximumReduce.HasValue)
                {
                    query = query.Where(x => x.MaximumReduce == request.MaximumReduce.Value);
                }
                if (request.ExchangePoint.HasValue)
                {
                    query = query.Where(x => x.ExchangePoint == request.ExchangePoint.Value);
                }

                if (request.ExpiresTime.HasValue)
                {
                    query = query.Where(x => x.ExpiresTime == request.ExpiresTime.Value);
                }

                return query;
            };

            var list = await _promotionRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
                 if (!list.Any())
            {
                throw new NotFoundException("Không tìm thấy Promotion");
            }
            return PagedResult<PromotionQuantityDto>.Create(
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToPromotionQuantityDtoList(_mapper));
        }
    }
}
