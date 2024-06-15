using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Application.Users;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion
{
    public class PromotionDto : IMapFrom<PromotionDto>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PromotionDto, PromotionDto>();
        }
        public required string Id { get; set; }
        public required decimal ConditionsOfUse { get; set; }
        public required float ReducedPercent { get; set; }
        public required decimal MaximumReduce { get; set; }
        public required int ExchangePoint { get; set; }
        public required DateTime ExpiresTime { get; set; }
        public string? UserID {  get; set; }
    }
}
