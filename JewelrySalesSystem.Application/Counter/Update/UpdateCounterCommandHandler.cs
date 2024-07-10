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

        public async Task<string> Handle(UpdateCounterCommand command, CancellationToken cancellationToken)
        {
            var checkExist = await _counterRepository.AnyAsync(x => x.Name == command.Name && x.DeletedAt == null, cancellationToken);
            if (checkExist)
            {
                throw new DuplicationException("Counter đã tồn tại");
            }

            var existEntity = await _counterRepository.FindAsync(x => x.ID == command.ID && x.DeletedAt == null, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            existEntity.Name = command.Name;
            existEntity.LastestUpdateAt = DateTime.Now;
            existEntity.UpdaterID = _currentUserService.UserId;

            _counterRepository.Update(existEntity);
            return await _counterRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
