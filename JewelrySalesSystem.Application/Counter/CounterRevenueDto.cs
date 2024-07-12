using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Counter
{
    public class CounterRevenueDto : IMapFrom<CounterEntity>
    {
        public CounterRevenueDto() { }
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrdersNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CounterEntity, CounterRevenueDto>();
        }
        public CounterRevenueDto(int id, string name, decimal totalPrice, int ordersNumber)
        {
            ID = id;
            Name = name;
            TotalPrice = totalPrice;
            OrdersNumber = ordersNumber;
        }
    }
}
