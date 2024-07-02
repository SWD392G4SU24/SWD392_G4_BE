using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JewelrySalesSystem.Application.Role.Update
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, string>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly ICurrentUserService _currentUserService;
        public UpdateRoleCommandHandler(IRoleRepository roleRepository, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _roleRepository = roleRepository;
        }
        public async Task<string> Handle(UpdateRoleCommand command, CancellationToken cancellationToken)
        {
            var checkExist = await _roleRepository.AnyAsync(x => x.Name == command.Name && x.DeletedAt == null, cancellationToken);
            if (checkExist)
            {
                throw new DuplicationException("Role đã tồn tại");
            }

            var existEntity = await _roleRepository.FindAsync(x => x.ID == command.ID && x.DeletedAt == null, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            existEntity.Name = command.Name;
            existEntity.UpdaterID = _currentUserService.UserId;
            existEntity.LastestUpdateAt = DateTime.UtcNow;
            _roleRepository.Update(existEntity);
            return await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
