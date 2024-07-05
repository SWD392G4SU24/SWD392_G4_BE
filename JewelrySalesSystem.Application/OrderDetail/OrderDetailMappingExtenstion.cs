using AutoMapper;
using JewelrySalesSystem.Application.Order;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail
{
    public static class OrderDetailMappingExtenstion
    {
        public static OrderDetailDto MapToOrderDetailDto(this OrderDetailEntity projectFrom, IMapper mapper)
      => mapper.Map<OrderDetailDto>(projectFrom);
        public static List<OrderDetailDto> MapToOrderDetailDtoList(this IEnumerable<OrderDetailEntity> projectFrom, IMapper mapper)
         => projectFrom.Select(x => x.MapToOrderDetailDto(mapper)).ToList();
    }
}
