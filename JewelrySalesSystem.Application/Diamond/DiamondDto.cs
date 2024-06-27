using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon
{
    public class DiamondDto : IMapFrom<DiamondDto>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DiamondDto, DiamondDto>();
        }
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required decimal BuyCost { get; set; }
        public required decimal SellCost { get; set; }
    }
}
