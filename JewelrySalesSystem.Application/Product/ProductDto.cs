using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities;


namespace JewelrySalesSystem.Application.Product
{
    public class ProductDto : IMapFrom<ProductEntity>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductEntity, ProductDto>();
        }
        public string Name {  get; set; }
        public required string Id { get; set; }
        public required decimal WageCost { get; set; }
        public float? GoldWeight { get; set; }
        public int? GoldID { get; set; }
        public string? GoldType { get; set; }
        public int? DiamondID { get; set; }
        public string? DiamondType { get; set; }
        public string? ImageURL { get; set; }
        public required int Quantity { get; set; }
        public string? Description { get; set; }
        public required int CategoryID { get; set; }
        public string Category {  get; set; }
    }
}
