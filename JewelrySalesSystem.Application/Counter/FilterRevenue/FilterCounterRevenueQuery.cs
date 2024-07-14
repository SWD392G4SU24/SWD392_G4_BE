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
    public class FilterCounterRevenueQuery : IRequest<List<CounterRevenueDto>>, IQuery
    {
        public FilterCounterRevenueQuery()
        {
            
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set;}
        public int? CounterID { get; set; } = 0;

    }
}
