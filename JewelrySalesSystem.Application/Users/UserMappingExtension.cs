using AutoMapper;
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

        public static UserDto MapToUserDto(this UserEntity entity, IMapper mapper, string role)
        {
            var dto = mapper.Map<UserDto>(entity);
            dto.Role = role;
            return dto;
        }
        public static List<UserDto> MapToUserDtoList(this IEnumerable<UserEntity> entities, IMapper mapper, Dictionary<int, string> role)
            => entities.Select(x =>
            x.MapToUserDto(mapper,              
                role.ContainsKey(x.RoleID) ? role[x.RoleID] : "Lỗi"
            )).ToList();
    }
}
