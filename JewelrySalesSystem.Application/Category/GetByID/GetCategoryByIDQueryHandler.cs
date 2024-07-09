using AutoMapper;
using JewelrySalesSystem.Application.Category;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;

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

        public async Task<CategoryDto> Handle(GetCategoryByIDQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(c => c.ID == request.Id && c.DeletedAt == null, cancellationToken);
            return category == null ? null : _mapper.Map<CategoryDto>(category);
        }
    }
}
