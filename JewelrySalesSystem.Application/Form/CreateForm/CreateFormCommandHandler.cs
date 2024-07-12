using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Form.CreateForm
{
    public class CreateFormCommandHandler : IRequestHandler<CreateFormCommand, string>
    {   
        private readonly IFormRepository _formRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateFormCommandHandler(IFormRepository formRepository, IOrderRepository orderRepository, ICurrentUserService currentUserService)
        {
            _formRepository = formRepository;
            _orderRepository = orderRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateFormCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindAsync(x => x.ID == request.OrderId && x.DeletedAt == null, cancellationToken);
            if (order == null)
            {
                throw new NotFoundException("Đơn hàng không tồn tại");
            }

            if (request.Type.Equals(FormType.REFUND) &&
                (order.Status.Equals(OrderStatus.PAID) || order.Status.Equals(OrderStatus.COMPLETED)) &&
                 (DateTime.Now - (DateTime)order.LastestUpdateAt).TotalDays > 2)
            {
                return "Đơn hàng đã thanh toán quá 2 ngày sẽ không được chọn REFUND, Vui lòng chọn lại Type";
            }

            if (request.Type.Equals(FormType.REFUND) &&
                !order.Status.Equals(OrderStatus.PAID) && !order.Status.Equals(OrderStatus.COMPLETED))
            {
                return "Đơn hàng vẫn còn đang trong tình trạng " + order.Status + " sẽ không được chọn REFUND, Vui lòng chọn lại Type";
            }

            if (request.Type.Equals(FormType.MAINTENANCE) &&
                 order.Status.Equals(OrderStatus.COMPLETED) &&
                 (DateTime.Now - (DateTime)order.LastestUpdateAt).TotalDays > 750)
            {
                return "Đơn hàng đã thanh toán quá 2 năm sẽ không được chọn MAINTENANCE, Vui lòng chọn lại Type";
            }

            if (request.Type.Equals(FormType.MAINTENANCE) &&
                  !order.Status.Equals(OrderStatus.COMPLETED))
            {
                return "Đơn hàng vẫn còn đang trong tình trạng " + order.Status + " sẽ không được chọn MAINTENANCE, Vui lòng chọn lại Type";
            }


            var form = new FormEntity
                {
                    AppoinmentDate = DateTime.Today.AddDays(2),
                    Content = request.Content.IsNullOrEmpty() ? null : request.Content,
                    Status = FormStatus.PENDING,
                    Type = request.Type,
                    CreatedAt = DateTime.Now,
                    CreatorID = _currentUserService.UserId,
                };
                _formRepository.Add(form);
                return await _formRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
            }
        
    }
}
