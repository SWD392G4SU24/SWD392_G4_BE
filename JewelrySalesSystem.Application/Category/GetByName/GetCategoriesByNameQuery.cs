using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;

namespace JewelrySalesSystem.Application.Category.GetByName
{
    public class GetCategoriesByNameQuery : IRequest<PagedResult<CategoryDto>>, IQuery
    {
        public GetCategoriesByNameQuery() { }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }

        public GetCategoriesByNameQuery(int pageNumber, int pageSize, string name)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Name = name;
        }
    }
}
