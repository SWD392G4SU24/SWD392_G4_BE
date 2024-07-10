using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Category.GetByPagination
{
    public class GetCategoryByPaginationQuery : IQuery, IRequest<PagedResult<CategoryDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetCategoryByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetCategoryByPaginationQuery() { }
    }
}
