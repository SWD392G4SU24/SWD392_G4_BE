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

        public static ProductDto MapToProductDto(this ProductEntity entity, IMapper mapper, string? goldType, string? diamondType, string category, decimal productCost)
        {
            var dto = mapper.Map<ProductDto>(entity);
            dto.GoldType = goldType;
            dto.DiamondType = diamondType;
            dto.Category = category;
            dto.ProductCost = productCost;
            return dto;
        }

        public static List<ProductDto> MapToProductDtoList(this IEnumerable<ProductEntity> entities, IMapper mapper, Dictionary<int, string>? goldType, Dictionary<int, string>? diamondType, Dictionary<int, string> category, Dictionary<string, decimal> productCost)
            => entities.Select(x =>
            x.MapToProductDto(mapper,
                x.GoldID.HasValue && goldType != null && goldType.ContainsKey(x.GoldID.Value) ? goldType[x.GoldID.Value] : null,
                x.DiamondID.HasValue && diamondType != null && diamondType.ContainsKey(x.DiamondID.Value) ? diamondType[x.DiamondID.Value] : null,
                category.ContainsKey(x.CategoryID) ? category[x.CategoryID] : "Lỗi",
                productCost.ContainsKey(x.ID) ? productCost[x.ID] : 0
            )).ToList();

    }
}
