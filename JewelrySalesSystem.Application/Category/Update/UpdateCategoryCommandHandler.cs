using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;

namespace JewelrySalesSystem.Application.Category.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, string>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, ICurrentUserService currentUserService)
        {
            _categoryRepository = categoryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(c => c.ID == request.Id && c.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Không tồn tại Category với ID: " + request.Id);

            category.Name = request.Name;
            category.LastestUpdateAt = DateTime.Now;
            category.UpdaterID = _currentUserService.UserId;

            _categoryRepository.Update(category);
            return await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
