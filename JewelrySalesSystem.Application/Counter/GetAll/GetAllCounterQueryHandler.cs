using AutoMapper;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using JewelrySalesSystem.Application.Role.GetAll;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Counter.GetAll
{
    public class GetAllCounterQueryHandler : IRequestHandler<GetAllCounterQuery, List<CounterDto>>
    {
        private readonly ICounterRepository _counterRepository;
        private readonly IMapper _mapper;

        public GetAllCounterQueryHandler(ICounterRepository counterRepository, IMapper mapper)
        {
            _counterRepository = counterRepository;
            _mapper = mapper;
        }

        public async Task<List<CounterDto>> Handle(GetAllCounterQuery request, CancellationToken cancellationToken)
        {
            var query = await _counterRepository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
            if (query == null)
            {
                throw new NotFoundException("Không tìm thấy Role nào");
            }
            return query.MapToCounterDtoList(_mapper);
        }
    }
}
