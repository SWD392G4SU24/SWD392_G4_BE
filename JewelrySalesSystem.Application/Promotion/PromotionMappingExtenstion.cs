using AutoMapper;
using JewelrySalesSystem.Application.Product;
using JewelrySalesSystem.Application.Promotion.GetByUser;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion
{
    public static class PromotionMappingExtenstion
    {
        public static PromotionDto MapToPromotionDto(this PromotionEntity projectFrom, IMapper mapper)
                  => mapper.Map<PromotionDto>(projectFrom);
        public static List<PromotionDto> MapToPromotionDtoList(this IEnumerable<PromotionEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToPromotionDto(mapper)).ToList();

        public static PromotionByUserDto MapToPromotionByUserDto(this IGrouping<string, PromotionEntity> group, IMapper mapper)
                  =>  new PromotionByUserDto
        {
            Quantity = group.Count(),
                      promotions = group.Select(entity => entity.MapToPromotionDto(mapper)).ToList()
        };
    public static List<PromotionByUserDto> MapToPromotionByUserDtoList(this IEnumerable<PromotionEntity> entities, IMapper mapper)
            => entities
            .GroupBy(x => x.Description)
            .Select(group => group.MapToPromotionByUserDto(mapper))
            .ToList();
    }
}
