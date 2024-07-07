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
            var counter = await _counterRepository.FindAsync(x => x.ID == request.ID && x.DeletedAt == null, cancellationToken);

            if (counter == null)
            {
                throw new NotFoundException("Không tồn tại quầy hàng");
            }

            counter.DeletedAt = DateTime.Now;
            counter.DeleterID = _currentUser.UserId;

            _counterRepository.Update(counter);
            return await _counterRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa thành công" : "Xóa thất bại";
        }
    }
}
