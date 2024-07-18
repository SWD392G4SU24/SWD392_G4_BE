using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using MediatR;

namespace JewelrySalesSystem.Application.Counter.GetByName
{
    public class GetCountersByNameQuery : IRequest<PagedResult<CounterDto>>, IQuery
    {
        public GetCountersByNameQuery() { }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }

        public GetCountersByNameQuery(int pageNumber, int pageSize, string name)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Name = name;
        }
    }
}
