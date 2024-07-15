using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.GetTotalRevenue
{
    public class GetTotalOrderRevenueQueryHandler : IRequestHandler<GetTotalOrderRevenueQuery, Dictionary<int, OrderRevenueDto>>
    {
        private readonly IOrderRepository _orderRepository;
        public GetTotalOrderRevenueQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Dictionary<int, OrderRevenueDto>> Handle(GetTotalOrderRevenueQuery request, CancellationToken cancellationToken)
        {
            Dictionary<int, OrderRevenueDto> result = new Dictionary<int, OrderRevenueDto>();
            decimal revenue = 0;
            decimal totalReOrder = 0;
            int completeOrers = 0;
            int refundOrders = 0;
            int reOrders = 0;

            for (int i = 1; i <= 13; i++)
            {
                result.Add(i, new OrderRevenueDto());
            }
            var orderList = await _orderRepository.FindAllAsync(x => x.DeletedAt == null
                && x.LastestUpdateAt.Value.Year == request.Year
                && x.Status != OrderStatus.PENDING, cancellationToken);
            foreach (var order in orderList)
            {
                if (order.Type != OrderType.RE_ORDER)
                {
                    if (order.Status == OrderStatus.REFUNDED)
                    {
                        refundOrders ++;
                        result[order.LastestUpdateAt.Value.Month].RefundOrders++;
                    }
                    if (order.Status == OrderStatus.PAID || order.Status == OrderStatus.COMPLETED)
                    {
                        completeOrers++;
                        revenue += order.TotalCost;

                        result[order.LastestUpdateAt.Value.Month].CompleteOrers++;
                        result[order.LastestUpdateAt.Value.Month].Revenue += order.TotalCost;
                    }
                }
                if (order.Type == OrderType.RE_ORDER)
                {
                    revenue -= order.TotalCost;
                    reOrders++;
                    totalReOrder += order.TotalCost;

                    result[order.LastestUpdateAt.Value.Month].TotalReOrder += order.TotalCost;
                    result[order.LastestUpdateAt.Value.Month].Revenue -= order.TotalCost;
                    result[order.LastestUpdateAt.Value.Month].ReOrders++;
                }                              
            }
            result[13].Revenue = revenue;
            result[13].RefundOrders = refundOrders;
            result[13].TotalReOrder = totalReOrder;
            result[13].CompleteOrers = completeOrers;
            result[13].ReOrders = reOrders;
            return result;
        }
    }
}
