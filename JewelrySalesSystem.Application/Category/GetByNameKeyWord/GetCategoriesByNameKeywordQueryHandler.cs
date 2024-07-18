using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Category.GetByNameKeyword
{
    public class GetCategoriesByNameKeywordQueryHandler : IRequestHandler<GetCategoriesByNameKeywordQuery, PagedResult<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesByNameKeywordQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CategoryDto>> Handle(GetCategoriesByNameKeywordQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<CategoryEntity>, IQueryable<CategoryEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.DeletedAt == null);
                if (!string.IsNullOrEmpty(request.Keyword))
                {
                    query = query.Where(x => x.Name.Contains(request.Keyword));
                }
                return query;
            };

            var result = await _categoryRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy category với từ khóa đã chọn");
            }

            return PagedResult<CategoryDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToCategoryDtoList(_mapper));
        }
    }
}
