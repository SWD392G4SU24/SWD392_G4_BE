using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.Delete
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, string>
    {
        IRoleRepository _roleRepository;
        ICurrentUserService _currentUser;
        public DeleteRoleCommandHandler(IRoleRepository roleRepository, ICurrentUserService currentUserService)
        {
            _roleRepository = roleRepository;
            _currentUser = currentUserService;
        }
        public async Task<string> Handle(DeleteRoleCommand command, CancellationToken cancellationToken)
        {
            var existEntity = await _roleRepository.FindAsync(x => x.ID == command.ID && x.DeletedAt == null, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            existEntity.DeleterID = _currentUser.UserId;
            existEntity.DeletedAt = DateTime.Now;
            _roleRepository.Update(existEntity);
            return await _roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa thành công" : "Xóa thất bại";
        }
    }
}
