using AutoMapper;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role
{
    public static class RoleMappingExtension
    {
        public static RoleDto MapToRoleDto(this RoleEntity projectFrom, IMapper mapper)
            => mapper.Map<RoleDto>(projectFrom);
        public static List<RoleDto> MapToRoleDtoList(this IEnumerable<RoleEntity> projectFrom, IMapper mapper)
            => projectFrom.Select(x => x.MapToRoleDto(mapper)).ToList();
    }
}
