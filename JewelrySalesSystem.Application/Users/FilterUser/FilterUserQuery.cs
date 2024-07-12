using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.FilterUser
{
    public class FilterUserQuery : IRequest<PagedResult<UserDto>>, IQuery
    {
        public FilterUserQuery()
        {
            
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? FullName {  get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RoleID { get; set; } = 0;
        public FilterUserQuery(int no, int pageSize)
        {
            PageNumber = no;
            PageSize = pageSize;
        }
    }
}
