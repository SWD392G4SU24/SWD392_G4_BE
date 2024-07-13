using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.GetByUserID
{
    public class GetOrderByUserIDQuery : IRequest<PagedResult<OrderDto>>, IQuery
    {
        public GetOrderByUserIDQuery()
        {
            
        }
        public GetOrderByUserIDQuery(string userID, int pageNumber, int pageSize)
        {
            UserID = userID;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string UserID {  get; set; }
    }
}
