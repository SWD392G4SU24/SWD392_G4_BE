using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, UsersLoginDto>
    {
        private readonly IMapper _mapper;
        private readonly IUsersRepository _repository;
        private readonly IRoleRepository _roleRepository;
        public LoginQueryHandler(IMapper mapper, IUsersRepository usersRepository, IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _repository = usersRepository;
            _mapper = mapper;
        }
        public async Task<UsersLoginDto> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _repository.FindAsync(x => x.Email == query.user.Email && x.DeletedAt == null, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException($"Không tìm thấy tài khoản nào với email - {query.user.Email}");
            }
            if(user != null)
            {
                var role = await _roleRepository.FindAsync(x => x.ID == user.RoleID && x.DeletedAt == null, cancellationToken);
                if (role == null)
                {
                    throw new NotFoundException($"Không tìm thấy tài khoản với role - {query.user.Email}");
                }

                var checkPassword = _repository.VerifyPassword(query.user.Password, user.PasswordHash);
                if (checkPassword)
                {
                    return UsersLoginDto.Create(user.Email, user.ID, role.Name);
                }
            }
            throw new NotFoundException("Tài khoản hoặc mật khẩu không đúng.");
        }
    }
}
