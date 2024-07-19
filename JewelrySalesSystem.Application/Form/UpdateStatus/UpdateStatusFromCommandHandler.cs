using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using Npgsql.Replication.PgOutput.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Form.UpdateStatus
{
    public class UpdateStatusFromCommandHandler : IRequestHandler<UpdateStatusFromCommand, string>
    {
        private readonly IFormRepository _formRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateStatusFromCommandHandler(IFormRepository formRepository
            , ICurrentUserService currentUserService
            , IOrderRepository orderRepository)
        {
            _formRepository = formRepository;
            _currentUserService = currentUserService;
            _orderRepository = orderRepository;
        }

        public async Task<string> Handle(UpdateStatusFromCommand request, CancellationToken cancellationToken)
        {
            var form = await _formRepository.FindAsync(x => x.ID == request.FormID && x.DeletedAt == null, cancellationToken)
            ?? throw new NotFoundException("Không tìm thấy form nào");
            if (!form.Status.Equals(FormStatus.PENDING))
            {
                return "Form đã được xử lý !!!";
            }
            var order = await _orderRepository.FindAsync(x => form.Content.Contains(x.ID), cancellationToken);
            if (order == null)
            {
                throw new NotFoundException("Đơn hàng không còn tồn tại");
            }

            form.Status = request.Status;
            if (form.Status.Equals(FormStatus.APPROVED) && form.Type.Equals(FormType.REFUND))
            {              
                order.Status = OrderStatus.REFUNDED;
                _orderRepository.Update(order);
            }

            form.LastestUpdateAt = DateTime.Now;
            form.UpdaterID = _currentUserService.UserId;
            _formRepository.Update(form);
            return await _formRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
