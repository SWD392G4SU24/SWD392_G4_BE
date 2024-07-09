using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.GetAll
{
    public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQuery, List<RoleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IRoleRepository _repository;
        public GetAllRoleQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = roleRepository;
        }

        public async Task<List<RoleDto>> Handle(GetAllRoleQuery query, CancellationToken cancellationToken)
        {
            var responseList = await _repository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
            if(!responseList.Any())
            {
                throw new NotFoundException("Không tìm thấy Role nào");
            }
            return responseList.MapToRoleDtoList(_mapper);
        }
    }
}
