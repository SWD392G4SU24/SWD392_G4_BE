using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Role;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.GetByPagination
{
    public class GetPaymentMethodByPaginationQuery : IQuery, IRequest<PagedResult<PaymentMethodDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetPaymentMethodByPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public GetPaymentMethodByPaginationQuery() { }
    }
}
