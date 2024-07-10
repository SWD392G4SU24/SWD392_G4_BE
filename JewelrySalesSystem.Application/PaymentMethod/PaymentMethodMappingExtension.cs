using AutoMapper;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod
{
    public static class PaymentMethodMappingExtension
    {
        public static PaymentMethodDto MapToPaymentMethodDto(this PaymentMethodEntity projectFrom, IMapper mapper)
            => mapper.Map<PaymentMethodDto>(projectFrom);
        public static List<PaymentMethodDto> MapToPaymentMethodDtoList(this IEnumerable<PaymentMethodEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToPaymentMethodDto(mapper)).ToList();
    }
}
