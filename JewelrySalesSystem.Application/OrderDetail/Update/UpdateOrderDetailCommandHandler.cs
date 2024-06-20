using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.OrderDetail.Create;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.Update
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, string>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, ICurrentUserService currentUserService)
        {
            _orderDetailRepository = orderDetailRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepository.FindAsync(s => s.ID == request.Id, cancellationToken);
            if (orderDetail is null) throw new NotFoundException("OrderDetail is not exist");
            // Updated Ordetail field
            orderDetail.OrderID = request.OrderID;
            orderDetail.ProductCost = request.ProductCost;
            orderDetail.ProductID = request.ProductID;
            orderDetail.Quantity = request.Quantity;
            orderDetail.DiamondSellCost = request.DiamondSellCost;
            orderDetail.GoldBuyCost = request.GoldBuyCost;
            orderDetail.GoldSellCost = request.GoldSellCost;
            orderDetail.LastestUpdateAt = DateTime.Now;
            orderDetail.UpdaterID = _currentUserService.UserId;
            _orderDetailRepository.Update(orderDetail);
            await _orderDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Updated OrderDetail Successfully";

        }
    }

}
