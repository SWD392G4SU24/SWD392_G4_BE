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

namespace JewelrySalesSystem.Application.Users.AssignStaff
{
    public class AssignStaffCommandHandler : IRequestHandler<AssignStaffCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;
        private readonly ICounterRepository _counterRepository;
        public AssignStaffCommandHandler(ICurrentUserService currentUserService
            , IUserRepository userRepository
            , ICounterRepository counterRepository)
        {
            _counterRepository = counterRepository;
            _currentUserService = currentUserService;
            _userRepository = userRepository;
        }
        public async Task<string> Handle(AssignStaffCommand query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.ID == query.StaffID && x.DeletedAt == null, cancellationToken);
            if(user == null)
            {
                throw new NotFoundException("Không tìm thấy Staff với ID: " + query.StaffID);
            }
            var existCounter = await _counterRepository.AnyAsync(x => x.ID == query.CounterID && x.DeletedAt == null, cancellationToken);
            if (!existCounter)
            {
                throw new NotFoundException("Không tìm thấy quầy bán với ID: " + query.CounterID);
            }
            
            user.CounterID = query.CounterID;
            user.LastestUpdateAt = DateTime.Now;
            user.UpdaterID = _currentUserService.UserId;
            _userRepository.Update(user);
            return await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
