using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users
{
    public class StaffRevenueDto : IMapFrom<UserEntity>
    {
        public StaffRevenueDto()
        {
            
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserEntity, StaffRevenueDto>();
        }
        public string ID { get; set; }
        public string FullName { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrdersNumber { get; set; }
        public StaffRevenueDto(string id, string fullname, decimal totalPrice, int ordersNumber)
        {
            ID = id;
            FullName = fullname;
            TotalPrice = totalPrice;
            OrdersNumber = ordersNumber;
        }
    }
}
