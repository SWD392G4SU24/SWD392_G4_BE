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
    public class DeleteOrderDetailQueryHandler : IRequestHandler<DeleteOrderDetailQuery, string>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, ICurrentUserService currentUserService)
        {
            _orderDetailRepository = orderDetailRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepository.GetOrderDetailByIdAsnyc(request.Id, cancellationToken);
            if (orderDetail == null) throw new NotFoundException("OrderDetailID : " + request.Id + "is not found");
            orderDetail.DeleterID = _currentUserService.UserId;
            orderDetail.DeletedAt = DateTime.Now;
            _orderDetailRepository.Update(orderDetail);
            await _orderDetailRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Deleted OrderDetail Successfully";
        }
    }
}
