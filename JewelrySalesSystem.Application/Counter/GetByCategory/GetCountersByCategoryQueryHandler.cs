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

namespace JewelrySalesSystem.Application.Counter.GetByCategory
{
    public class GetCountersByCategoryQueryHandler : IRequestHandler<GetCountersByCategoryQuery, PagedResult<CounterDto>>
    {
        private readonly ICounterRepository _counterRepository;
        private readonly IMapper _mapper;

        public GetCountersByCategoryQueryHandler(ICounterRepository counterRepository, IMapper mapper)
        {
            _counterRepository = counterRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CounterDto>> Handle(GetCountersByCategoryQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<CounterEntity>, IQueryable<CounterEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.DeletedAt == null);
                query = query.Where(x => x.CategoryID == request.CategoryID);
                return query;
            };

            var result = await _counterRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy counters trong category đã chọn");
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
