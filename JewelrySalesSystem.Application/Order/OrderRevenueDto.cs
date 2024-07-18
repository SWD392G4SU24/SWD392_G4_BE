using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order
{
    public class OrderRevenueDto
    {
        public decimal Revenue { get; set; }
        public decimal TotalReOrder {  get; set; }
        public int CompleteOrers { get; set; }
        public int RefundOrders { get; set; }
        public int ReOrders {  get; set; }
    }
}
