using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;
using Castle.Core.Resource;
using JewelrySalesSystem.Domain.Entities.EmailModel;
using System.Security.Policy;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Application.Common.Interfaces;

namespace JewelrySalesSystem.Application.Users.CreateAccount
{
    public class CreateAccountCommandHandler : IRequestHandler<CreateAccountCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IEmailVerificationRepository _emailVerificationRepository;
        private readonly IEmailSender _emailSender;
        private readonly ICurrentUserService _currentUserService;
        public CreateAccountCommandHandler(IUserRepository userRepository
            , IRoleRepository roleRepository
            , IEmailVerificationRepository emailVerificationRepository
            , IEmailSender emailSender
            , ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _emailVerificationRepository = emailVerificationRepository;
            _emailSender = emailSender;
        }
        public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var currentAccount = await _userRepository.FindAsync(x => x.ID.Equals(_currentUserService.UserId) && x.DeletedAt == null, cancellationToken);
            if(currentAccount == null)
            {
                throw new NotFoundException("Tài khoản bị xóa hoặc không tồn tại");
            }
            if(currentAccount.RoleID != 1)
            {
                return "Tài khoản không đủ quyền hạn";
            }

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
            var role = await _roleRepository.FindAsync(x => x.ID == request.RoleID && x.DeletedAt == null, cancellationToken);
            if (role == null)
            {
                throw new NotFoundException("Role không tồn tại");
            }
            var password = _userRepository.GeneratePassword();
            var user = new UserEntity
            {
                Address = request.Address,
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                PasswordHash = _userRepository.HashPassword(password),
                RoleID = request.RoleID,
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
                            $"Mật khẩu của bạn là: {password}<br>" +
                            $"Hãy bấm vào <a href='{callbackUrl}'>link này</a> để xác nhận<br>" +
                            $"Trân Trọng";
            await _emailSender.SendEmailAsync(user.Email, emailSubject, emailBody);

            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return user.ID;
        }
    }
}
