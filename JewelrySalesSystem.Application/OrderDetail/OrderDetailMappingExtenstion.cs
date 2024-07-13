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

        public static OrderDetailDto MapToOrderDetailDto(this OrderDetailEntity projectFrom, IMapper mapper, string product, string? productImgUrl)
        {
            var dto = mapper.Map<OrderDetailDto>(projectFrom);
            dto.Product = product;
            dto.ProductImgUrl = productImgUrl;
            return dto;
        }
        public static List<OrderDetailDto> MapToOrderDetailDtoList(this IEnumerable<OrderDetailEntity> projectFrom, IMapper mapper, Dictionary<string, string> product, Dictionary<string, string> productImgUrl)
         => projectFrom.Select(x => x.MapToOrderDetailDto(mapper,
             product.ContainsKey(x.ProductID) ? product[x.ProductID] : "Lỗi",
             x.Product.ImageURL != null && productImgUrl != null && productImgUrl.ContainsKey(x.ProductID) ? productImgUrl[x.ProductID] : null
             )).ToList();
    }
}
