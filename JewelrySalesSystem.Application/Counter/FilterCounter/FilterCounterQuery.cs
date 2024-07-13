using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using MediatR;

namespace JewelrySalesSystem.Application.Counter.FilterCounter
{
    public class FilterCounterQuery : IRequest<PagedResult<CounterDto>>, IQuery
    {
        public FilterCounterQuery() { }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public int? CategoryID { get; set; } = 0;

        public FilterCounterQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
