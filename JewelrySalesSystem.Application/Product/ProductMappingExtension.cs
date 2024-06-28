using AutoMapper;
using JewelrySalesSystem.Domain.Entities;


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
