using AutoMapper;
using JewelrySalesSystem.Application.Diamon;
using JewelrySalesSystem.Application.OrderDetail;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order
{
    public static class OrderMappingExtenstion
    {
        public static OrderDto MapToOrderDto(this OrderEntity projectFrom, IMapper mapper)
            => mapper.Map<OrderDto>(projectFrom);
        public static List<OrderDto> MapToOrderDtoList(this IEnumerable<OrderEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToOrderDto(mapper)).ToList();


        public static OrderDto MapToOrderDto(this OrderEntity projectFrom, IMapper mapper, string? counter, string fullName, string paymentMethod, Dictionary<string, string> productNames, Dictionary<string, string> productImgUrl)
        {
            var dto = mapper.Map<OrderDto>(projectFrom);
            dto.Counter = counter;
            dto.FullName = fullName;
            dto.PaymentMethod = paymentMethod;
            dto.Type = projectFrom.Type.ToString();
            dto.Status = projectFrom.Status.ToString();
            dto.OrderDetailsDto = projectFrom.OrderDetails.MapToOrderDetailDtoList(mapper, productNames, productImgUrl);
            return dto;
        }
        public static List<OrderDto> MapToOrderDtoList(this IEnumerable<OrderEntity> projectFrom, IMapper mapper, Dictionary<int, string> counter, Dictionary<string, string> fullName, Dictionary<int, string> paymentMethod, Dictionary<string, string> productNames, Dictionary<string, string> productImgUrl)
            => projectFrom.Select(x => x.MapToOrderDto(mapper,
                x.CounterID.HasValue && counter != null && counter.ContainsKey(x.CounterID.Value) ? counter[x.CounterID.Value] : null,
                fullName.ContainsKey(x.BuyerID) ? fullName[x.BuyerID] : "Lỗi",
                paymentMethod.ContainsKey(x.PaymentMethodID) ? paymentMethod[x.PaymentMethodID] : "Lỗi",
                productNames,
                productImgUrl
                )).ToList();

    }
}
