using AutoMapper;
using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.CurrrentUser
{
    public class GetCurrentUserQueryHandler : IRequestHandler<GetCurrentUserQuery, UserDto>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        public GetCurrentUserQueryHandler(ICurrentUserService currentUserService
            , IMapper mapper
            , IUserRepository userRepository
            , IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _currentUserService = currentUserService;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.ID == _currentUserService.UserId && x.DeletedAt == null, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("Không tìm thấy user hiện tại");
            }
            var role = await _roleRepository.FindAsync(x => x.ID.Equals(user.RoleID) && x.DeletedAt == null, cancellationToken);
            if (role == null)
            {
                throw new NotFoundException("Không tìm thấy role của User");
            }
            return user.MapToUserDto(_mapper, role.Name);
        }
    }
}
