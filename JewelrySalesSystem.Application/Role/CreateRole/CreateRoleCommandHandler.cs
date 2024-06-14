using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreateRoleCommandHandler(IRoleRepository roleRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _roleRepository = roleRepository;
        }
        public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
           var existRole = await _roleRepository.AnyAsync(x => x.Name == request.Name && x.DeletedAt == null, cancellationToken);
           if (existRole)
           {
                throw new DuplicationException("Role đã tồn tại");
           }
           RoleEntity role = new RoleEntity 
           {
               Name = request.Name ,
               CreatedAt = DateTime.Now,
               CreatorID = _currentUserService.UserId
           };
            _roleRepository.Add(role);
            return await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken) == 1 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
