using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Counter.GetByPagination
{
    public class GetCounterByPaginationQuery : IQuery, IRequest<PagedResult<CounterDto>>
    {
        public int PageNumber {  get; set; }
        public int PageSize { get; set; }
        public GetCounterByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetCounterByPaginationQuery() { }
    }
}
