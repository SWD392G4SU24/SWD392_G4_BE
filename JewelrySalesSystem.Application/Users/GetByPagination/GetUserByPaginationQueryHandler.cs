using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.GetByPagination
{
    public class GetUserByPaginationQueryHandler : IRequestHandler<GetUserByPaginationQuery, PagedResult<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ICounterRepository _counterRepository;
        public GetUserByPaginationQueryHandler(IMapper mapper
            , IUserRepository userRepository
            , IRoleRepository roleRepository
            , ICounterRepository counterRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _counterRepository = counterRepository;
        }
        public async Task<PagedResult<UserDto>> Handle(GetUserByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _userRepository.FindAllAsync(x => x.DeletedAt == null, query.PageNumber, query.PageSize, cancellationToken);
            
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
