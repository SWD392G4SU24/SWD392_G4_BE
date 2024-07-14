using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;

namespace JewelrySalesSystem.Application.Category.GetByNameKeyword
{
    public class GetCategoriesByNameKeywordQuery : IRequest<PagedResult<CategoryDto>>, IQuery
    {
        public GetCategoriesByNameKeywordQuery() { }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Keyword { get; set; }

        public GetCategoriesByNameKeywordQuery(int pageNumber, int pageSize, string keyword)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Keyword = keyword;
        }
    }
}
