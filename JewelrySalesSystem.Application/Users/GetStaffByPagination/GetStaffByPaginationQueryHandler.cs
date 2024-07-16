using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Users.GetByPagination;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.GetStaffByPagination
{
    public class GetStaffByPaginationQueryHandler : IRequestHandler<GetStaffByPaginationQuery, PagedResult<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;
        public GetStaffByPaginationQueryHandler(IMapper mapper, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task<PagedResult<UserDto>> Handle(GetStaffByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _userRepository.FindAllAsync(x => x.DeletedAt == null && x.Role.Name.Equals("Staff"), query.PageNumber, query.PageSize, cancellationToken);
            var roles = await _roleRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);
            return PagedResult<UserDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToUserDtoList(_mapper, roles)
                );
        }
    }
}
