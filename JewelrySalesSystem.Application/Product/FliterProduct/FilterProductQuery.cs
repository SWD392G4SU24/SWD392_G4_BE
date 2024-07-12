using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Pagination;
using MediatR;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product.FliterProduct
{
    public class FilterProductQuery :  IRequest<PagedResult<ProductDto>>, IQuery
    {
        public FilterProductQuery() { }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Name { get; set; }
        public int? GoldID { get; set; } = 0;
        public int? DiamondID { get; set; } = 0;
        public int? CategoryID { get; set; } = 0;

        public FilterProductQuery(int no, int pageSize)
        {
            PageNumber = no;
            PageSize = pageSize;
        }
    }
}
