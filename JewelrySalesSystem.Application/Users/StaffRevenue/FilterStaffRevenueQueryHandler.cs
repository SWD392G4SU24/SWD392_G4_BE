using AutoMapper;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelrySalesSystem.Domain.Entities.Configured;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using Microsoft.IdentityModel.Tokens;

namespace JewelrySalesSystem.Application.Users.StaffRevenue
{
    public class FilterStaffRevenueQueryHandler : IRequestHandler<FilterStaffRevenueQuery, List<StaffRevenueDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        public FilterStaffRevenueQueryHandler(IMapper mapper
            , IUserRepository userRepository
            , IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _orderRepository = orderRepository;
        }
        public async Task<List<StaffRevenueDto>> Handle(FilterStaffRevenueQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<UserEntity>, IQueryable<UserEntity>> queryoptions = query =>
            {
                if (!string.IsNullOrEmpty(request.StaffID))
                {
                    query = query.Where(x => x.ID == request.StaffID);
                }
                query = query.Where(x => x.Orders.Any(y => y.CreatedAt <= request.EndDate
                    && y.CreatedAt >= request.StartDate
                    && y.DeletedAt == null
                    && (y.Status.Equals(OrderStatus.COMPLETED))
                    ));
                return query;
            };
            var result = await _userRepository.FindAllAsync(x => x.DeletedAt == null, queryoptions, cancellationToken);

            Dictionary<string, decimal> total = new Dictionary<string, decimal>();
            Dictionary<string, int> ordersCount = new Dictionary<string, int>();
            var orders = await _orderRepository.FindAllAsync(x => result.Contains(x.User) && x.DeletedAt == null, cancellationToken);
            foreach (var order in orders)
            {
                if (!string.IsNullOrEmpty(order.CreatorID))
                {
                    string staffID = order.CreatorID;

                    if (!total.ContainsKey(staffID))
                    {
                        total.Add(staffID, order.TotalCost);
                    }
                    else
                    {
                        total[staffID] += order.TotalCost;
                    }

                    if (!ordersCount.ContainsKey(staffID))
                    {
                        ordersCount.Add(staffID, 1);
                    }
                    else
                    {
                        ordersCount[staffID]++;
                    }
                }
            }
            return result.MapToStaffRevenueDtoList(_mapper, total, ordersCount);
        }
    }
}
