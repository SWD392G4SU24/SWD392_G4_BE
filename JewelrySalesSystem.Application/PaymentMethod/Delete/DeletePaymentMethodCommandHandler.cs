using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.Delete
{
    public class DeletePaymentMethodCommandHandler : IRequestHandler<DeletePaymentMethodCommand, string>
    {
        IPaymentMethodRepository _paymentMethodRepository;
        ICurrentUserService _currentUser;
        public DeletePaymentMethodCommandHandler(IPaymentMethodRepository paymentMethodRepository, ICurrentUserService currentUserService)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _currentUser = currentUserService;
        }

        public async Task<string> Handle(DeletePaymentMethodCommand command, CancellationToken cancellationToken)
        {
            var existEntity = await _paymentMethodRepository.FindAsync(x => x.ID == command.ID && x.DeletedAt == null, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            existEntity.DeletedAt = DateTime.Now;
            existEntity.DeleterID = _currentUser.UserId;
            _paymentMethodRepository.Update(existEntity);
            return await _paymentMethodRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xoá thành công" : "Xoá thất bại";
        }
    }
}
