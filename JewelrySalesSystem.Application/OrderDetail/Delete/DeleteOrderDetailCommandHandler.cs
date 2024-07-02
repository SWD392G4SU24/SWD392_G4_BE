using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.Delete
{
    public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, string>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, ICurrentUserService currentUserService)
        {
            _orderDetailRepository = orderDetailRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepository.FindAsync(s => s.ID == request.Id && s.DeletedAt == null, cancellationToken);
            if (orderDetail is null) throw new NotFoundException("OrderDetail không tồn tại");
            orderDetail.DeleterID = _currentUserService.UserId;
            orderDetail.DeletedAt = DateTime.Now;
            _orderDetailRepository.Update(orderDetail);
            
            return await _orderDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken) == 1 ? "Xóa OrderDetail thành công" : "Xóa OrderDetail thất bại";
        }
    }
}
