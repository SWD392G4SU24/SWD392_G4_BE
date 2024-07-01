using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities.Configured;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.GoldBtmc
{
    public class GoldDto : IMapFrom<GoldEntity>
    {
        public string Name { get; set; }
        public string KaraContent { get; set; }
        public float GoldContent { get; set; }
        public decimal BuyCost { get; set; }
        public decimal SellCost { get; set; }
        public DateTime CreatedAt { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GoldEntity,GoldDto>();
        }
    }
}
