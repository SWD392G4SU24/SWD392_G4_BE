using AutoMapper;
using JewelrySalesSystem.Domain.Entities.Configured;
using System.Collections.Generic;
using System.Linq;

namespace JewelrySalesSystem.Application.Category
{
    public static class CategoryMappingExtension
    {
        public static CategoryDto MapToCategoryDto(this CategoryEntity entity, IMapper mapper)
            => mapper.Map<CategoryDto>(entity);

        public static List<CategoryDto> MapToCategoryDtoList(this IEnumerable<CategoryEntity> entities, IMapper mapper)
            => entities.Select(x => x.MapToCategoryDto(mapper)).ToList();
    }
}