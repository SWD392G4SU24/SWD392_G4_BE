
using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.GetByID
{
    public class GetByIDQueryHandler : IRequestHandler<GetByIDQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;

        public GetByIDQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<OrderDto> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            // Logic to retrieve orders base on query parameters(if any)
            var order = await _orderRepository.GetOrderByIdAsnyc(request.Id, cancellationToken);
            if (order is null) throw new NotFoundException("OrderID is not exist");
            return new OrderDto
            {
               BuyerID = order.BuyerID,
               ID = order.ID,
               Note = order.Note,
               PaymentMethodID = order.PaymentMethodID,
               TotalCost = order.TotalCost,
               Type = order.Type,
               CounterID = order.CounterID,
               PromotionID = order.PromotionID,
            };
        }
    }
}
