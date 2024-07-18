using AutoMapper;
using JewelrySalesSystem.Application.Product;
using JewelrySalesSystem.Application.Promotion.GetByUser;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion
{
    public static class PromotionMappingExtenstion
    {
        public static PromotionDto MapToPromotionDto(this PromotionEntity projectFrom, IMapper mapper)
                  => mapper.Map<PromotionDto>(projectFrom);
        public static List<PromotionDto> MapToPromotionDtoList(this IEnumerable<PromotionEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToPromotionDto(mapper)).ToList();

        public static PromotionQuantityDto MapToPromotionQuantityDto(this PromotionEntity entity, IMapper mapper)
        {
            var dto = mapper.Map<PromotionQuantityDto>(entity);
            return dto;
        }

        public static List<PromotionQuantityDto> MapToPromotionQuantityDtoList(this IEnumerable<PromotionEntity> projectFrom, IMapper mapper)
          => projectFrom
        .GroupBy(x => new { x.Description, x.ConditionsOfUse, x.ReducedPercent, x.MaximumReduce, x.ExchangePoint, x.ExpiresTime })
        .Select(g => 
        {
            var dto = g.First().MapToPromotionQuantityDto(mapper);
            dto.Quantity = g.Count();
            return dto;
        })
        .ToList();
    }
}
