using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.GetByPagination
{
    public class GetRoleByPaginationQuery : IQuery, IRequest<PagedResult<RoleDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetRoleByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetRoleByPaginationQuery() { }
    }
}
