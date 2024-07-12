using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;

namespace JewelrySalesSystem.Application.Category.FilterCategory
{
    public class FilterCategoryQuery : IRequest<PagedResult<CategoryDto>>, IQuery
    {
        public FilterCategoryQuery()
        {

        }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }

        public FilterCategoryQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
