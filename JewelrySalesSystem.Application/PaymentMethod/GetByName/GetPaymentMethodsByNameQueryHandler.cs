using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.GetByName
{
    public class GetPaymentMethodsByNameQueryHandler : IRequestHandler<GetPaymentMethodsByNameQuery, PagedResult<PaymentMethodDto>>
    {
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IMapper _mapper;

        public GetPaymentMethodsByNameQueryHandler(IPaymentMethodRepository paymentMethodRepository, IMapper mapper)
        {
            _paymentMethodRepository = paymentMethodRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<PaymentMethodDto>> Handle(GetPaymentMethodsByNameQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<PaymentMethodEntity>, IQueryable<PaymentMethodEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.DeletedAt == null);
                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(x => x.Name.Contains(request.Name));
                }
                return query;
            };

            var result = await _paymentMethodRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy phương thức thanh toán với tên đã chọn");
            }

            return PagedResult<PaymentMethodDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToPaymentMethodDtoList(_mapper));
        }
    }
}
