using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.GetByPagination
{
    public class GetRoleByPaginationQueryHandler : IRequestHandler<GetRoleByPaginationQuery, PagedResult<RoleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        public GetRoleByPaginationQueryHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }

        public async Task<PagedResult<RoleDto>> Handle(GetRoleByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _roleRepository.FindAllAsync(x => x.DeletedAt == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<RoleDto>.Create
                (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToRoleDtoList(_mapper)
                );
        }
    }
}
