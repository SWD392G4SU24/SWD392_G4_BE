using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Counter.GetByPagination
{
    public class GetCounterByPaginationQueryHandler : IRequestHandler<GetCounterByPaginationQuery, PagedResult<CounterDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICounterRepository _counterRepository;
        public GetCounterByPaginationQueryHandler(IMapper mapper, ICounterRepository counterRepository)
        {
            _mapper = mapper;
            _counterRepository = counterRepository;
        }
        public async Task<PagedResult<CounterDto>> Handle(GetCounterByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _counterRepository.FindAllAsync(x => x.DeletedAt == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<CounterDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToCounterDtoList(_mapper)
                );
        }
    }
}
