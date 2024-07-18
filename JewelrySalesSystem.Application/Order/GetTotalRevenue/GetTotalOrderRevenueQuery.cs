using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.GetTotalRevenue
{
    public class GetTotalOrderRevenueQuery : IRequest<Dictionary<int, OrderRevenueDto>>, IQuery
    {
        public GetTotalOrderRevenueQuery()
        {
            
        }
        public int Year { get; set; }
    }
}
