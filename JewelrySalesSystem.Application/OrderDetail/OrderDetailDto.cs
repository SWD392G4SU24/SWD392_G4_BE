using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail
{
    public class OrderDetailDto : IMapFrom<OrderDetailDto>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDetailDto, OrderDetailDto>();
        }
        public required string ID { get; set; }
        public required string OrderID { get; set; }
        public required string ProductID { get; set; }
        public required int Quantity { get; set; }
        public required decimal ProductCost { get; set; } // TotalCost của detail
        public decimal? GoldSellCost { get; set; } // Gía bán cho customer
        public decimal? GoldBuyCost { get; set; } // Gía mua lại từ customer
        public decimal? DiamondSellCost { get; set; }

    }
}
