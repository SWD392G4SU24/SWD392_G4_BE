using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
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
        private readonly IRoleRepository _roleRepository;
        public RegisterCommandHandler(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;

        }
        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _userRepository.AnyAsync(x => x.Email == request.Email && x.DeletedAt == null, cancellationToken);
            if (isExist)
            {
                throw new DuplicationException("Email is existed");
            }
            isExist = await _userRepository.AnyAsync(x => x.Email == request.PhoneNumber && x.DeletedAt == null, cancellationToken);
            if (isExist)
            {
                throw new DuplicationException("Phone number is existed");
            }
            var role = await _roleRepository.FindAsync(x => x.ID == request.RoleID && x.DeletedAt == null, cancellationToken);
            if (role == null)
            {
                throw new NotFoundException("Role is not exist");
            }          
            var user = new UserEntity
            {
                Address = request.Address,
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                FullName = request.FullName,
                PasswordHash = _userRepository.HashPassword(request.Password),
                RoleID = request.RoleID,
                CreatedAt = DateTime.UtcNow,       
                Status = UserStatus.UNVERIFIED,
                Point = 0,
            };
            _userRepository.Add(user);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return user.ID;
        }
    }
}
