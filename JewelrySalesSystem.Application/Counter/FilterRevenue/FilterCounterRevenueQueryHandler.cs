using AutoMapper;
using JewelrySalesSystem.Application.Common.Models;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Counter.FilterRevenue
{
    public class FilterCounterRevenueQueryHandler : IRequestHandler<FilterCounterRevenueQuery, PagedResult<CounterRevenueDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICounterRepository _counterRepository;
        private readonly IOrderRepository _orderRepository;
        public FilterCounterRevenueQueryHandler(IMapper mapper, ICounterRepository counterRepository, IOrderRepository orderRepository)
        {
            _counterRepository = counterRepository;
            _mapper = mapper;
            _orderRepository = orderRepository;
        }
        public async Task<PagedResult<CounterRevenueDto>> Handle(FilterCounterRevenueQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<CounterEntity>, IQueryable<CounterEntity>> queryoptions = query =>
            {
                query = query.Where(x => x.DeletedAt == null);
                if (request.CounterID != 0)
                {
                    query = query.Where(x => x.ID == request.CounterID);
                }
                query = query.Where(x => x.Orders.Any(y => y.CreatedAt <= request.EndDate
                    && y.CreatedAt >= request.StartDate
                    && y.DeletedAt == null
                    && (y.Status.Equals(OrderStatus.PAID) || y.Status.Equals(OrderStatus.COMPLETED))
                    ));
                return query;
            };
            var result = await _counterRepository.FindAllAsync(request.PageNumber, request.PageSize, queryoptions, cancellationToken);

            Dictionary<int, decimal> total = new Dictionary<int, decimal>();
            Dictionary<int, int> ordersCount = new Dictionary<int, int>();

            var orders = await _orderRepository.FindAllAsync(x => result.Contains(x.Counter) && x.DeletedAt == null, cancellationToken);
            foreach (var order in orders)
            {
                if (order.CounterID.HasValue)
                {
                    int counterID = order.CounterID.Value;

                    if (!total.ContainsKey(counterID))
                    {
                        total.Add(counterID, order.TotalCost);
                    }
                    else
                    {
                        total[counterID] += order.TotalCost;
                    }

                    if (!ordersCount.ContainsKey(counterID))
                    {
                        ordersCount.Add(counterID, 1);
                    }
                    else
                    {
                        ordersCount[counterID]++;
                    }
                }
            }

            return PagedResult<CounterRevenueDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToCounterRevenueDtoList(_mapper, total, ordersCount));
        }
    }
}
