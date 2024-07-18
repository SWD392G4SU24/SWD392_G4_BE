using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Users.GetStaffByPagination;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.GetManagerByPagination
{
    public class GetManagerByPaginationQueryHandler : IRequestHandler<GetManagerByPaginationQuery, PagedResult<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICounterRepository _counterRepository;
        public GetManagerByPaginationQueryHandler(IMapper mapper
            , IUserRepository userRepository
            , IRoleRepository roleRepository
            , ICounterRepository counterRepository)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _counterRepository = counterRepository;
        }
        public async Task<PagedResult<UserDto>> Handle(GetManagerByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _userRepository.FindAllAsync(x => x.DeletedAt == null && x.Role.Name.Equals("Manager"), query.PageNumber, query.PageSize, cancellationToken);
            var roles = await _roleRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);
            var counters = await _counterRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);

            return PagedResult<UserDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToUserDtoList(_mapper, roles, counters)
                );
        }
    }
}