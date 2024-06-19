using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.GetAll
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, IEnumerable<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            // Logic to retrieve orders base on query parameters(if any)
            var orders = await _orderRepository.GetAllOrdersAsync(cancellationToken);
            return orders.Select(s => new OrderDto
            {
                ID = s.ID,
                BuyerID = s.BuyerID,
                Note = s.Note,
                PaymentMethodID = s.PaymentMethodID,
                TotalCost = s.TotalCost,
                Type = s.Type,
                CounterID = s.CounterID,
                PromotionID = s.PromotionID,
            }).ToList();
        }
    }
}
