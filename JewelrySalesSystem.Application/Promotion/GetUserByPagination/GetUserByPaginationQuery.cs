using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetByUser
{
    public class GetUserByPaginationQuery : IRequest<PagedResult<PromotionDto>>, IQuery
    {
        public GetUserByPaginationQuery() { }
        
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string UserId { get; set; }

        public GetUserByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
