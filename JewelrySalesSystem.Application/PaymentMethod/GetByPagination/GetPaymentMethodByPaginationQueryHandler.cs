using AutoMapper;
using AutoMapper.QueryableExtensions;
using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JewelrySalesSystem.Application.PaymentMethod.GetByPagination
{
    public class GetPaymentMethodByPaginationQueryHandler : IRequestHandler<GetPaymentMethodByPaginationQuery, PagedResult<PaymentMethodDto>>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;
        public GetPaymentMethodByPaginationQueryHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }
        public async Task<PagedResult<PaymentMethodDto>> Handle(GetPaymentMethodByPaginationQuery query, CancellationToken cancellationToken)
        {
            var list = await _paymentMethodRepository.FindAllAsync(x => x.DeletedAt == null, query.PageNumber, query.PageSize, cancellationToken);
            return PagedResult<PaymentMethodDto>.Create
            (
                totalCount: list.TotalCount,
                pageCount: list.PageCount,
                pageSize: list.PageSize,
                pageNumber: list.PageNo,
                data: list.MapToPaymentMethodDtoList(_mapper)
                );
        }
    }
}
