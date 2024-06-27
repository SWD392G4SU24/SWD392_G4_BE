using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon
{
    public class DiamonDto : IMapFrom<DiamonDto>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DiamonDto, DiamonDto>();
        }
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required decimal BuyCost { get; set; }
        public required decimal SellCost { get; set; }
    }
}
