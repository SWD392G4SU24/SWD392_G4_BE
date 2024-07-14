using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;
using System;

namespace JewelrySalesSystem.Application.PaymentMethod.GetByDateRange
{
    public class GetPaymentMethodsByDateRangeQuery : IRequest<PagedResult<PaymentMethodDto>>, IQuery
    {
        public GetPaymentMethodsByDateRangeQuery() { }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public GetPaymentMethodsByDateRangeQuery(int pageNumber, int pageSize, DateTime startDate, DateTime endDate)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
