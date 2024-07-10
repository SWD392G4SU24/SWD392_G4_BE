using AutoMapper;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Category
{
    public static class CategoryMappingExtension
    {
        public static CategoryDto MapToCategoryDto(this CategoryEntity projectFrom, IMapper mapper)
            => mapper.Map<CategoryDto>(projectFrom);

        public static List<CategoryDto> MapToCategoryDtoList(this IEnumerable<CategoryEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToCategoryDto(mapper)).ToList();
    }
}