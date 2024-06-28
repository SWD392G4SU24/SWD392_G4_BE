using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.GetAll
{
    public class GetAllRoleQuery : IRequest<List<RoleDto>>, IQuery
    {
        public GetAllRoleQuery()
        {
            
        }
    }
}
