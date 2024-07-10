using AutoMapper;
using JewelrySalesSystem.Application.Category;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using JewelrySalesSystem.Domain.Commons.Exceptions;

namespace JewelrySalesSystem.Application.Category.GetByID
{
    public class GetCategoryByIDQueryHandler : IRequestHandler<GetCategoryByIDQuery, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryByIDQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryByIDQuery query, CancellationToken cancellationToken)
        {
            var existEntity = await _categoryRepository.FindAsync(c => c.ID == query.Id && c.DeletedAt == null, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            return existEntity.MapToCategoryDto(_mapper);
        }
    }
}
