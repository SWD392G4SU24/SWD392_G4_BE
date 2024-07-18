using JewelrySalesSystem.Application.Users.VerifyAccount;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Users.VerifyEmail
{
    public class VerifyEmailCommandHandler : IRequestHandler<VerifyEmailCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailVerificationRepository _emailVerificationRepository;
        public VerifyEmailCommandHandler(IUserRepository userRepository
            , IEmailVerificationRepository emailVerificationRepository)
        {
            _emailVerificationRepository = emailVerificationRepository;
            _userRepository = userRepository;
        }
        public async Task<string> Handle(VerifyEmailCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.ID == request.UserID && x.DeletedAt == null, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("Không tìm thấy tài khoản");
            }
            var emailVerification = await _emailVerificationRepository.FindAsync(x => x.Token == request.Token && x.ExpiryDate >= DateTime.UtcNow && request.UserID.Equals(x.CustomerID), cancellationToken);
            if (emailVerification == null)
            {
                return "Token không hợp lệ hoặc đã hết hạn";
            }
            user.Status = UserStatus.VERIFIED;
            _emailVerificationRepository.Remove(emailVerification);
            _userRepository.Update(user);
            return await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xác thực thành công" : "Xác thực thất bại";
        }
    }
}
