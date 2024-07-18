using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using MediatR;

namespace JewelrySalesSystem.Application.Counter.GetByCategory
{
    public class GetCountersByCategoryQuery : IRequest<PagedResult<CounterDto>>, IQuery
    {
        public GetCountersByCategoryQuery() { }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int CategoryID { get; set; }

        public GetCountersByCategoryQuery(int pageNumber, int pageSize, int categoryID)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            CategoryID = categoryID;
        }
    }
}
