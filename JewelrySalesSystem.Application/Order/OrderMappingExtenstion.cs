using AutoMapper;
using JewelrySalesSystem.Application.Diamon;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order
{
    public static class OrderMappingExtenstion
    {
        public static OrderDto MapToOrderDto(this OrderEntity projectFrom, IMapper mapper)
       => mapper.Map<OrderDto>(projectFrom);
        public static List<OrderDto> MapToOrderDtoList(this IEnumerable<OrderEntity> projectFrom, IMapper mapper)
         => projectFrom.Select(x => x.MapToOrderDto(mapper)).ToList();
    }
}
