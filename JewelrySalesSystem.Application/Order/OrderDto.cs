using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order
{
    public class OrderDto : IMapFrom<OrderDto>
    {
        public void Mapping(Profile profile)
        {

            profile.CreateMap<OrderDto, OrderDto>();

        }
        public required string ID {  get; set; }
        public required string Note { get; set; }
        public required string Type { get; set; }
        public required decimal TotalCost { get; set; }
        public string? PromotionID { get; set; }
        public int? CounterID { get; set; }
        public required string BuyerID { get; set; }
        public required int PaymentMethodID { get; set; }
    }
}
