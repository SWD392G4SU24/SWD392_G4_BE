using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.CreateOrder
{
    public class CreateOrderCommandHanlder : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateOrderCommandHanlder(IOrderRepository orderRepository, ICurrentUserService currentUserService)
        {
            _orderRepository = orderRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new OrderEntity
            {
                BuyerID = request.BuyerID,
                Note = request.Note,
                PaymentMethodID = request.PaymentMethodID,
                TotalCost = request.TotalCost,
                Type = request.Type,
                PromotionID = request.PromotionID,
                CounterID = request.CounterID,
                CreatorID = _currentUserService.UserId,
                CreatedAt = DateTime.Now,
                Status = OrderStatus.PENDING
            };
             _orderRepository.Add(order);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Create Order Successfully with ID: " + order.ID;
        }
    }
}
