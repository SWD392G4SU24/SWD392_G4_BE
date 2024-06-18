using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Gold
{
    public class GoldDto : IMapFrom<GoldDto>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GoldDto, GoldDto>();
        }
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required float KaraContent { get; set; }
        public required float GoldContent { get; set; }
        public required decimal BuyCost { get; set; }
        public required decimal SellCost { get; set; }
    }
}
