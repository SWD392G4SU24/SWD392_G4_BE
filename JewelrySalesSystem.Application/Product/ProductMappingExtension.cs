using AutoMapper;
using JewelrySalesSystem.Application.GoldBtmc;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product
{
    public static class ProductMappingExtension
    {
        public static ProductDto MapToProductDto(this ProductEntity projectFrom, IMapper mapper)
                   => mapper.Map<ProductDto>(projectFrom);
        public static List<ProductDto> MapToProductDtoList(this IEnumerable<ProductEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToProductDto(mapper)).ToList();
    }
}
