using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.GetById
{
    public class GetRoleByIdQueryHandler : IRequestHandler<GetRoleByIdQuery, RoleDto>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _roleRepository;
        public GetRoleByIdQueryHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            _mapper = mapper;
            _roleRepository = roleRepository;
        }
        public async Task<RoleDto> Handle(GetRoleByIdQuery query, CancellationToken cancellationToken)
        {
            var existEntity = await _roleRepository.FindAsync(x => x.ID == query.ID && x.DeletedAt == null, cancellationToken);
            if (existEntity == null)
            {
                throw new NotFoundException("ID không tồn tại");
            }
            return existEntity.MapToRoleDto(_mapper);
        }
    }
}
