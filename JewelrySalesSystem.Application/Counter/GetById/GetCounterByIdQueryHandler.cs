using AutoMapper;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Counter.GetById
{
    public class GetCounterByIdQueryHandler : IRequestHandler<GetCounterByIdQuery, CounterDto>
    {
        private readonly ICounterRepository _counterRepository;
        private readonly IMapper _mapper;

        public GetCounterByIdQueryHandler(ICounterRepository counterRepository, IMapper mapper)
        {
            _counterRepository = counterRepository;
            _mapper = mapper;
        }

        public async Task<CounterDto> Handle(GetCounterByIdQuery request, CancellationToken cancellationToken)
        {
            var existEntity = await _counterRepository.FindAsync(x => x.DeletedAt == null && x.ID == request.ID, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            return existEntity.MapToCounterDto(_mapper);
        }
    }
}
