using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon
{
    public class DiamondDto : IMapFrom<DiamondEntity>
    {
        public required string Name { get; set; }
        public required decimal BuyCost { get; set; }
        public required decimal SellCost { get; set; }
        public DateTime CreateAt {  get; set; }
        public required int Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DiamondEntity, DiamondDto>();
        }
    }
}
