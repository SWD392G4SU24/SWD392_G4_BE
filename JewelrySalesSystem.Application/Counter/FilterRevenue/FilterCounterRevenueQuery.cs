using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Counter.FilterRevenue
{
    public class FilterCounterRevenueQuery : IRequest<PagedResult<CounterRevenueDto>>, IQuery
    {
        public FilterCounterRevenueQuery()
        {
            
        }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public int? CounterID { get; set; } = 0;
        public FilterCounterRevenueQuery(int no, int pageSize)
        {
            PageNumber = no;
            PageSize = pageSize;
        }

    }
}
