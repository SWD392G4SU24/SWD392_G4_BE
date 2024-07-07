using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Counter.Update
{
    public class UpdateCounterCommandHandler : IRequestHandler<UpdateCounterCommand, string>
    {
        private readonly ICounterRepository _counterRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateCounterCommandHandler(ICounterRepository counterRepository, ICurrentUserService currentUserService)
        {
            _counterRepository = counterRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateCounterCommand request, CancellationToken cancellationToken)
        {
            var existCounter = await _counterRepository.FindAsync(x => x.DeletedAt == null && x.ID == request.ID, cancellationToken);
            if (existCounter == null)
            {
                throw new NotFoundException("Không tìm thấy Counter");
            }

            var checkExistName = await _counterRepository.AnyAsync(x => x.DeletedAt == null && x.Name == request.Name && x.ID != request.ID, cancellationToken);
            if (checkExistName)
            {
                throw new DuplicationException("Counter đã tồn tại");
            }

            existCounter.Name = request.Name;
            existCounter.CategoryID = request.CategoryID;
            existCounter.LastestUpdateAt = DateTime.Now;
            existCounter.UpdaterID = _currentUserService.UserId;

            _counterRepository.Update(existCounter);
            return await _counterRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
