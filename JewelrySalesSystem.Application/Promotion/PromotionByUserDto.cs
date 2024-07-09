using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion
{
    public class PromotionByUserDto : IMapFrom<PromotionEntity>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PromotionEntity, PromotionByUserDto>();
        }
        //public string Description { get; set; }
        public int Quantity { get; set; }
        public List<PromotionDto> promotions { get; set; }
    }
}
