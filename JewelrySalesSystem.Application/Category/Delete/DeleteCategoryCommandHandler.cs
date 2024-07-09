using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;

namespace JewelrySalesSystem.Application.Category.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, string>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, ICurrentUserService currentUserService)
        {
            _categoryRepository = categoryRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(c => c.ID == request.Id && c.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Category không tồn tại");

            category.DeletedAt = DateTime.Now;
            category.DeleterID = _currentUserService.UserId;

            _categoryRepository.Update(category);
            return await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa category thành công" : "Xóa category thất bại";
        }
    }
}
