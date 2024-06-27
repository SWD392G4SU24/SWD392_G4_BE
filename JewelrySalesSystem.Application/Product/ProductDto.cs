using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product
{
    public class ProductDto : IMapFrom<ProductEntity>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductEntity, ProductDto>();
        }
        public required string Id { get; set; }
        public required decimal WageCost { get; set; }
        public float? GoldWeight { get; set; }
        public int? GoldType { get; set; }
        public int? DiamonType { get; set; }
        public string? ImageURL { get; set; }
        public required int Quantity { get; set; }
        public string? Description { get; set; }
        public required int CategoryID { get; set; }
    }
}
