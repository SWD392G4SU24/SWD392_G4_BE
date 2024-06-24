using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.GoogleLogin
{
    public class GoogleLoginQueryHandler : IRequestHandler<GoogleLoginQuery, UserLoginDto>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repository;
        private readonly IRoleRepository _roleRepository;

        public GoogleLoginQueryHandler(IMapper mapper, IUserRepository usersRepository, IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _repository = usersRepository;
            _mapper = mapper;
        }

        public async Task<UserLoginDto> Handle(GoogleLoginQuery query, CancellationToken cancellationToken)
        {
            var user = await _repository.FindAsync(x => x.Email == query.Email && x.DeletedAt == null, cancellationToken);

            if (user == null)
            {
                // If user does not exist, create a new user
                var defaultRole = await _roleRepository.FindAsync(x => x.Name == "User", cancellationToken);
                if (defaultRole == null)
                {
                    throw new NotFoundException("Default role not found.");
                }

                user = new UserEntity
                {
                    Email = query.Email,
                    FullName = query.FullName,
                    PasswordHash = "",
                    Username = query.Email,
                    PhoneNumber = "", 
                    Address = "", 
                    Point = 0,
                    RoleID = defaultRole.ID,
                    CreatedAt = DateTime.UtcNow
                };

                await _repository.AddAsync(user, cancellationToken);
            }

            var role = await _roleRepository.FindAsync(x => x.ID == user.RoleID && x.DeletedAt == null, cancellationToken);
            if (role == null)
            {
                throw new NotFoundException($"Role not found for user with email - {query.Email}");
            }

            return UserLoginDto.Create(user.Email, user.ID, role.Name);
        }
    }
}
