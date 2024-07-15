using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetByDesciption
{
    public class FilterPromotionQuery : IRequest<PagedResult<PromotionQuantityDto>>, IQuery
    {
        public string VoucherContent { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public  decimal? ConditionsOfUse { get; set; }
        public  float? ReducedPercent { get; set; }
        public  decimal? MaximumReduce { get; set; }
        public  int? ExchangePoint { get; set; }
        public DateTime? ExpiresTime { get; set; }
        public FilterPromotionQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public FilterPromotionQuery()
        {
        }
    }
}
