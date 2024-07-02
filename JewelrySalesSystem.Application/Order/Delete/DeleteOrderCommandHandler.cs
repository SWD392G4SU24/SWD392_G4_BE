using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.DeleteOrder
{
    public class DeleteOrdercommandHandler : IRequestHandler<DeleteOrdercommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteOrdercommandHandler(IOrderRepository orderRepository, ICurrentUserService currentUserService)
        {
            _orderRepository = orderRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeleteOrdercommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindAsync(s => s.ID == request.Id && s.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Order không tồn tại");
            order.DeletedAt = DateTime.UtcNow;
            order.DeleterID = _currentUserService.UserId;
            _orderRepository.Update(order);

            return await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa order thành công" : "Xóa order thất bại";
        }
    }
}
