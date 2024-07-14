using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;

namespace JewelrySalesSystem.Application.PaymentMethod.GetByName
{
    public class GetPaymentMethodsByNameQuery : IRequest<PagedResult<PaymentMethodDto>>, IQuery
    {
        public GetPaymentMethodsByNameQuery() { }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }

        public GetPaymentMethodsByNameQuery(int pageNumber, int pageSize, string name)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Name = name;
        }
    }
}
