using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Counter.Delete
{
    public class DeleteCounterCommandHandler : IRequestHandler<DeleteCounterCommand, string>
    {
        ICounterRepository _counterRepository;
        ICurrentUserService _currentUser;

        public DeleteCounterCommandHandler(ICounterRepository counterRepository, ICurrentUserService currentUserService)
        {
            _counterRepository = counterRepository;
            _currentUser = currentUserService;
        }

        public async Task<string> Handle(DeleteCounterCommand request, CancellationToken cancellationToken)
        {
            var existEntity = await _counterRepository.FindAsync(x => x.ID == request.ID && x.DeletedAt == null, cancellationToken);

            if (existEntity == null)
            {
                throw new NotFoundException("Counter tồn tại");
            }

            existEntity.DeletedAt = DateTime.Now;
            existEntity.DeleterID = _currentUser.UserId;
            _counterRepository.Update(existEntity);
            return await _counterRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa thành công" : "Xóa thất bại";
        }
    }
}
