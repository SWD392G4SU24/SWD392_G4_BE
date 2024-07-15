using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.StaffRevenue
{
    public class FilterStaffRevenueQuery : IRequest<List<StaffRevenueDto>>, IQuery
    {
        public FilterStaffRevenueQuery()
        {
            
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? StaffID { get; set; }
    }
}
