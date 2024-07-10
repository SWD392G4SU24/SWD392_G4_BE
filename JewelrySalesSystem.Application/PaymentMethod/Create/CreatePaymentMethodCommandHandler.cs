using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.CreatePaymentMethod
{
    public class CreatePaymentMethodCommandHandler : IRequestHandler<CreatePaymentMethodCommand, string>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreatePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _paymentMethodRepository = paymentMethodRepository;
        }
        public async Task<string> Handle(CreatePaymentMethodCommand request, CancellationToken cancellationToken)
        {
            var existPaymentMethod = await _paymentMethodRepository.AnyAsync(x => x.Name == request.Name && x.DeletedAt == null, cancellationToken);
            if (existPaymentMethod)
            {
                throw new DuplicationException("Payment method đã tồn tại");
            }
            PaymentMethodEntity paymentMethod = new PaymentMethodEntity
            {
                Name = request.Name,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId
            };
            _paymentMethodRepository.Add(paymentMethod);
            return await _paymentMethodRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
