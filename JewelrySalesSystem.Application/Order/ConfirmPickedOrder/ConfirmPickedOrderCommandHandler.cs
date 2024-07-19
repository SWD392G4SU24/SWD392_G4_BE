using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.ConfirmPickedOrder
{
    public class ConfirmPickedOrderCommandHandler : IRequestHandler<ConfirmPickedOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentUserService _currentUserService;
        public ConfirmPickedOrderCommandHandler(IOrderRepository orderRepository, ICurrentUserService currentUserService)
        {
            _orderRepository = orderRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(ConfirmPickedOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindAsync(x => x.ID == request.OrderID && x.DeletedAt == null, cancellationToken);
            if (order == null)
            {
                throw new NotFoundException("Đơn hàng không tồn tại");
            }
            if (!order.Status.Equals(OrderStatus.PAID))
            {
                return "Đơn hàng chưa được thanh toán hoặc đã được xử lý";
            }
            order.Status = OrderStatus.COMPLETED;
            order.PickupDate = DateTime.Now;
            order.LastestUpdateAt = DateTime.Now;
            order.UpdaterID = _currentUserService.UserId;
            return await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";

        }
    }
}
