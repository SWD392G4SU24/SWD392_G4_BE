using AutoMapper;
using JewelrySalesSystem.Application.Counter;
using JewelrySalesSystem.Application.Product;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users
{
    public static class UserMappingExtension
    {
        public static UserDto MapToUserDto(this UserEntity projectFrom, IMapper mapper)
            => mapper.Map<UserDto>(projectFrom);
        public static List<UserDto> MapToUserDtoList(this IEnumerable<UserEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToUserDto(mapper)).ToList();

        public static UserDto MapToUserDto(this UserEntity entity, IMapper mapper, string role, string? counter)
        {
            var dto = mapper.Map<UserDto>(entity);
            dto.Role = role;
            dto.Counter = counter;
            return dto;
        }
        public static List<UserDto> MapToUserDtoList(this IEnumerable<UserEntity> entities, IMapper mapper, Dictionary<int, string> role, Dictionary<int, string> counter)
            => entities.Select(x =>
            x.MapToUserDto(mapper,              
                role.ContainsKey(x.RoleID) ? role[x.RoleID] : "Lỗi",
                x.CounterID.HasValue && counter != null && counter.ContainsKey(x.CounterID.Value) ? counter[x.CounterID.Value] : null
            )).ToList();


        public static StaffRevenueDto MapToStaffRevenueDto(this UserEntity projectForm, IMapper mapper)
            => mapper.Map<StaffRevenueDto>(projectForm);
        public static StaffRevenueDto MapToStaffRevenueDto(this UserEntity projectForm, IMapper mapper, decimal totalPrice, int ordersNumber)
        {
            var dto = mapper.Map<StaffRevenueDto>(projectForm);
            dto.TotalPrice = totalPrice;
            dto.OrdersNumber = ordersNumber;
            return dto;
        }
        public static List<StaffRevenueDto> MapToStaffRevenueDtoList(this IEnumerable<UserEntity> entities, IMapper mapper, Dictionary<string, decimal> totalPrice, Dictionary<string, int> ordersNumber)
           => entities.Select(x =>
           x.MapToStaffRevenueDto(mapper,
               totalPrice.ContainsKey(x.ID) ? totalPrice[x.ID] : 0,
               ordersNumber.ContainsKey(x.ID) ? ordersNumber[x.ID] : 0
           )).ToList();
    }
}
