using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.OrderDetail.Update;
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
            var orderDetail = await _orderDetailRepository.FindAsync(s => s.ID == request.Id, cancellationToken);
            if (orderDetail is null) throw new NotFoundException("OrderDetail is not exist");
            orderDetail.DeleterID = _currentUserService.UserId;
            orderDetail.DeletedAt = DateTime.Now;
            _orderDetailRepository.Update(orderDetail);
            await _orderDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Deleted OrderDetail Successfully";
        }
    }
}
