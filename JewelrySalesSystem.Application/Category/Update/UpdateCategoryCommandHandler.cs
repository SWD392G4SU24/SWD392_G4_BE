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

        public async Task<string> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var checkExist = await _categoryRepository.AnyAsync(c => c.Name == command.Name && c.DeletedAt == null, cancellationToken);
                if(checkExist)
            {
                throw new DuplicationException("Category đã tồn tại");
            }

            var existEntity = await _categoryRepository.FindAsync(x => x.ID == command.Id && x.DeletedAt == null, cancellationToken);
                if(existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }

            existEntity.Name = command.Name;
            existEntity.LastestUpdateAt = DateTime.Now;
            existEntity.UpdaterID = _currentUserService.UserId;

            _categoryRepository.Update(existEntity);
            return await _categoryRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
