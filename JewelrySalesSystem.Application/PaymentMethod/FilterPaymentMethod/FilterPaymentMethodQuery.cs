using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;

namespace JewelrySalesSystem.Application.PaymentMethod.FilterPaymentMethod
{
    public class FilterPaymentMethodQuery : IRequest<PagedResult<PaymentMethodDto>>, IQuery
    {
        public FilterPaymentMethodQuery() { }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }

        public FilterPaymentMethodQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
