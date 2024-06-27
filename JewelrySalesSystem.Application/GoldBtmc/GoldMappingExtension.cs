using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.GoldBtmc
{
    public static class GoldMappingExtension
    {
        public static GoldDto MapToGoldBtmcDto(this GoldEntity projectFrom, IMapper mapper)
            => mapper.Map<GoldDto>(projectFrom);
        public static List<GoldDto> MapToGoldBtmcDtoList(this IEnumerable<GoldEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToGoldBtmcDto(mapper)).ToList();
    }
}
