using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.Create
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, string>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, ICurrentUserService currentUserService)
        {
            _orderDetailRepository = orderDetailRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = new OrderDetailEntity
            {
                OrderID = request.OrderID,
                ProductCost = request.ProductCost,
                ProductID = request.ProductID,
                Quantity = request.Quantity,
                DiamondSellCost = request.DiamondSellCost,
                GoldBuyCost = request.GoldBuyCost,
                GoldSellCost = request.GoldSellCost,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId,
            };
            _orderDetailRepository.Add(orderDetail);
            await _orderDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Created OrderDetail Successfully" + orderDetail.ID;
        }
    }
}
