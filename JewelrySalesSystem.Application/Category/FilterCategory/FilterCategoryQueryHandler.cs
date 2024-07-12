using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;

namespace JewelrySalesSystem.Application.Category.FilterCategory
{
    public class FilterCategoryQueryHandler : IRequestHandler<FilterCategoryQuery, PagedResult<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public FilterCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CategoryDto>> Handle(FilterCategoryQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<CategoryEntity>, IQueryable<CategoryEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.DeletedAt == null);

                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(x => x.Name.Contains(request.Name));
                }

                return query;
            };

            var result = await _categoryRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy Category");
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
