using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICounterRepository _counterRepository;
        public UpdateUserCommandHandler(ICurrentUserService currentUserService, IUserRepository userRepository
            , ICounterRepository counterRepository, IRoleRepository roleRepository)
        {
            _counterRepository = counterRepository;
            _roleRepository = roleRepository;
            _currentUserService = currentUserService;
            _userRepository = userRepository;
        }
        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.ID == request.UserID && x.DeletedAt == null, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("Không tìm thấy User với ID: " + request.UserID);
            }

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                user.PasswordHash = _userRepository.HashPassword(request.Password);
            }

            if (request.Status.HasValue)
            {
                user.Status = request.Status.Value;
            }

            if (!string.IsNullOrWhiteSpace(request.FullName))
            {
                user.FullName = request.FullName;
            }

            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                user.Email = request.Email;
            }

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                user.PhoneNumber = request.PhoneNumber;
            }

            if (!string.IsNullOrWhiteSpace(request.Address))
            {
                user.Address = request.Address;
            }

            if (request.Point.HasValue)
            {
                user.Point = request.Point.Value;
            }

            if (request.RoleID.HasValue)
            {
                var exist = await _roleRepository.AnyAsync(x => x.ID == request.RoleID && x.DeletedAt == null, cancellationToken);
                if(!exist)
                {
                    throw new NotFoundException("Không tìm thấy role với ID: " + request.RoleID);
                }
                user.RoleID = request.RoleID.Value;
            }

            if (request.CounterID.HasValue)
            {
                var exist = await _counterRepository.AnyAsync(x => x.ID == request.CounterID && x.DeletedAt == null, cancellationToken);
                if (!exist)
                {
                    throw new NotFoundException("Không tìm thấy quầy bán với ID: " + request.CounterID);
                }
                user.CounterID = request.CounterID.Value;
            }    

            _userRepository.Update(user);
            return await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }    
}
