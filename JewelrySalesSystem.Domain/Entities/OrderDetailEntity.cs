﻿using JewelrySalesSystem.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Entities
{
    [Table("OrderDetail")]
    public class OrderDetailEntity : BaseEntity
    {
        public required string OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public virtual OrderEntity Order {  get; set; }
        public required string ProductID { get; set; }
        [ForeignKey(nameof(ProductID))]
        public virtual ProductEntity Product { get; set; }
        public required int Quantity {  get; set; }
        public required decimal ProductCost {  get; set; } // TotalCost của detail
        public decimal? GoldSellCost {  get; set; } // Gía bán cho customer
        public decimal? GoldBuyCost { get; set; } // Gía mua lại từ customer
        public decimal? DiamondSellCost { get; set; }
    }
}
