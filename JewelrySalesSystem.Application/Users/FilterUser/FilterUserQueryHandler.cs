using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.FilterUser
{
    public class FilterUserQueryHandler : IRequestHandler<FilterUserQuery, PagedResult<UserDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public FilterUserQueryHandler(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<UserDto>> Handle(FilterUserQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<UserEntity>, IQueryable<UserEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.DeletedAt == null);
                if (request.RoleID != 0)
                {
                    query = query.Where(x => x.RoleID.Equals(request.RoleID));
                }
                if (!string.IsNullOrEmpty(request.FullName))
                {
                    query = query.Where(x => x.FullName.Contains(request.FullName));
                }
                if (!string.IsNullOrEmpty(request.Email))
                {
                    query = query.Where(x => x.Email.Contains(request.Email));
                }
                if (!string.IsNullOrEmpty(request.PhoneNumber))
                {
                    query = query.Where(x => x.PhoneNumber.Contains(request.PhoneNumber));
                }
                return query;
            };

            var result = await _userRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy User");
            }
            var roles = await _roleRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);
            
            return PagedResult<UserDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToUserDtoList(_mapper, roles));
        }
    }
}
