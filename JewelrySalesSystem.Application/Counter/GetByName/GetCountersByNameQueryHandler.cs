using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Counter.GetByName
{
    public class GetCountersByNameQueryHandler : IRequestHandler<GetCountersByNameQuery, PagedResult<CounterDto>>
    {
        private readonly ICounterRepository _counterRepository;
        private readonly IMapper _mapper;

        public GetCountersByNameQueryHandler(ICounterRepository counterRepository, IMapper mapper)
        {
            _counterRepository = counterRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CounterDto>> Handle(GetCountersByNameQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<CounterEntity>, IQueryable<CounterEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.DeletedAt == null);
                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(x => x.Name.Contains(request.Name));
                }
                return query;
            };

            var result = await _counterRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy counter với tên đã chọn");
            }

            return PagedResult<CounterDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToCounterDtoList(_mapper));
        }
    }
}
