using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;

namespace JewelrySalesSystem.Application.Category.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, string>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, ICurrentUserService currentUserService)
        {
            _categoryRepository = categoryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new CategoryEntity
            {
                Name = request.Name,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId
            };

            _categoryRepository.Add(category);
            return await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
