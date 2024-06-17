using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MailKit.Search;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository, ICurrentUserService currentUserService)
        {
            _orderRepository = orderRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsnyc(request.ID, cancellationToken);
            if (order == null) throw new NotFoundException("OrderID : " + request.ID + "is not found");
            //Update Order
            order.BuyerID = request.BuyerID;
            order.Note = request.Note;
            order.PaymentMethodID = request.PaymentMethodID;
            order.TotalCost = request.TotalCost;
            order.Type = request.Type;
            order.PromotionID = request.PromotionID;
            order.CounterID = request.CounterID;
            order.UpdaterID = _currentUserService.UserId;
            order.LastestUpdateAt = DateTime.Now;
            _orderRepository.Update(order);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Updated Order Successfully";
        }
    }
}
