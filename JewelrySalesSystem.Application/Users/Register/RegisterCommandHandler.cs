using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.EmailModel;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Users.CreateNewUser
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailVerificationRepository _emailVerificationRepository;
        private readonly IEmailSender _emailSender;
        public RegisterCommandHandler(IUserRepository userRepository
            , IEmailVerificationRepository emailVerificationRepository
            , IEmailSender emailSender)
        {
            _emailVerificationRepository = emailVerificationRepository;
            _emailSender = emailSender;
            _userRepository = userRepository;

        }
        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _userRepository.AnyAsync(x => x.Email == request.Email && x.DeletedAt == null, cancellationToken);
            if (isExist)
            {
                throw new DuplicationException("Email đã được sử dụng");
            }
            isExist = await _userRepository.AnyAsync(x => x.Username == request.Username && x.DeletedAt == null, cancellationToken);
            if (isExist)
            {
                throw new DuplicationException("Username đã được sử dụng");
            }
            isExist = await _userRepository.AnyAsync(x => x.PhoneNumber == request.PhoneNumber && x.DeletedAt == null, cancellationToken);
            if (isExist)
            {
                throw new DuplicationException("Số điện thoại đã được sử dụng");
            }                   
            var user = new UserEntity
            {
                Address = request.Address,
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                PasswordHash = _userRepository.HashPassword(request.Password),
                RoleID = 3,   
                Status = UserStatus.UNVERIFIED,
                Point = 0,
            };
            _userRepository.Add(user);
            var token = Guid.NewGuid().ToString();
            var emailVerification = new EmailVerification
            {
                CustomerID = user.ID,
                Token = token,
                ExpiryDate = DateTime.Now.AddHours(24) // Token hết hạn sau 24 giờ
            };
            _emailVerificationRepository.Add(emailVerification);
            var callbackUrl = "http://localhost:5173/login1/?token=" + token + "&userid=" + user.ID;

            var emailSubject = "Xác Thực Tài Khoản";
            var emailBody = $"Chào Mừng Bạn Đã Đến Với JeWellry<br>" +
                            $"Hãy bấm vào <a href='{callbackUrl}'>link này</a> để xác nhận<br>" +
                            $"Trân Trọng";
            await _emailSender.SendEmailAsync(user.Email, emailSubject, emailBody);

            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return user.ID;
        }
    }
}
