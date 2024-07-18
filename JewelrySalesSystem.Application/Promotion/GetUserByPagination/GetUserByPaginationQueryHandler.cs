using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JewelrySalesSystem.Application.Promotion.GetByUser
{
    public class GetUserByPaginationQueryHandler : IRequestHandler<GetUserByPaginationQuery, PagedResult<PromotionDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public GetUserByPaginationQueryHandler(IUserRepository userRepository, IPromotionRepository promotionRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PromotionDto>> Handle(GetUserByPaginationQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.ID.Equals(request.UserId) 
                && !x.Status.Equals(UserStatus.BANNED) 
                && x.DeletedAt == null, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("Tài khoản không tồn tại hoặc đã bị BAN");

            }
            var result = await _promotionRepository.FindAllAsync(x => x.DeletedAt == null && x.UserID == request.UserId, request.PageNumber, request.PageSize, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy ưu đãi nào");
            }
            
            return PagedResult<PromotionDto>.Create
            (
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToPromotionDtoList(_mapper)
                );
        }
    }
}
