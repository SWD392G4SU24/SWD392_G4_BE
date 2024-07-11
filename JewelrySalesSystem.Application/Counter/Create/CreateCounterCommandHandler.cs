using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Counter.CreateCounter
{
    public class CreateCounterCommandHandler : IRequestHandler<CreateCounterCommand, string>
    {
        private readonly ICounterRepository _counterRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateCounterCommandHandler(ICounterRepository counterRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _counterRepository = counterRepository;
        }

        public async Task<string> Handle(CreateCounterCommand request, CancellationToken cancellationToken)
        {
            var existCounter = await _counterRepository.AnyAsync(x => x.Name == request.Name && x.DeletedAt == null, cancellationToken);
            if (existCounter)
            {
                throw new DuplicationException("Counter đã tồn tại");
            }

            CounterEntity counter = new CounterEntity
            {
                Name = request.Name,
                CategoryID = request.CategoryID,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId
            };

            _counterRepository.Add(counter);
            return await _counterRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
