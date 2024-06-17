using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.DeleteOrder
{
    public class DeleteOrderQueryHandler : IRequestHandler<DeleteOrderQuery, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteOrderQueryHandler(IOrderRepository orderRepository, ICurrentUserService currentUserService)
        {
            _orderRepository = orderRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteOrderQuery request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetOrderByIdAsnyc(request.Id, cancellationToken);
            if (order == null) throw new NotFoundException("OrderID :" + request.Id + "is not found");
            order.DeletedAt = DateTime.UtcNow;
            order.DeleterID = _currentUserService.UserId;
            _orderRepository.Update(order);
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Deleted Order Successfully";
        }
    }
}
