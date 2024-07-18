using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.FilterOrder
{
    public class FilterOrderQuery : IRequest<PagedResult<OrderDto>>, IQuery
    {
        public FilterOrderQuery()
        {
            
        }
        public FilterOrderQuery(int no, int pageSize)
        {
            PageNumber = no;
            PageSize = pageSize;
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public OrderType? Type { get; set; }
        public OrderStatus? Status { get; set; }
        public int? CounterID { get; set; } = 0;
        public string? BuyerID { get; set; }
        public int? PaymentMethodID { get; set; } = 0;
    }
}
