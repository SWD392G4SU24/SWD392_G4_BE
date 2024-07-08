using AutoMapper;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod
{
    public class PaymentMethodDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<PaymentMethodEntity, PaymentMethodDto>();
        }
    }
}
