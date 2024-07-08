using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.Update
{
    public class UpdatePaymentMethodCommandHandler : IRequestHandler<UpdatePaymentMethodCommand, string>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdatePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository, ICurrentUserService currentUserService)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(UpdatePaymentMethodCommand command, CancellationToken cancellationToken)
        {
            var checkExist = await _paymentMethodRepository.AnyAsync(x => x.Name == command.Name && x.DeletedAt == null, cancellationToken);
            if (checkExist)
            {
                throw new DuplicationException("Payment method đã tồn tại");
            }

            var existEntity = await _paymentMethodRepository.FindAsync(x => x.ID == command.ID && x.DeletedAt == null, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            existEntity.Name = command.Name;
            existEntity.UpdaterID = _currentUserService.UserId;
            existEntity.LastestUpdateAt = DateTime.UtcNow;
            return await _paymentMethodRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
