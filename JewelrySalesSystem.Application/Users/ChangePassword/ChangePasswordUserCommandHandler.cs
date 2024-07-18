using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.ChangePassword
{
    public class ChangePasswordUserCommandHandler : IRequestHandler<ChangePasswordUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;
        public ChangePasswordUserCommandHandler(IUserRepository userRepository, ICurrentUserService currentUserService)
        {
            _userRepository = userRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(ChangePasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.ID == _currentUserService.UserId && x.DeletedAt == null, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("Không tìm thấy tài khoản");
            }
            var verify = _userRepository.VerifyPassword(request.OldPassword, user.PasswordHash);
            if (!verify)
            {
                return ("Mật khẩu cũ không đúng");
            }
            var newPassword = _userRepository.HashPassword(request.NewPassword);
            user.PasswordHash = newPassword;
            _userRepository.Update(user);
            return await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Đổi mật khẩu thành công" : "Đổi mật khẩu thất bại";
        }
    }
}
