﻿using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.Update
{
    public class UpdateOrderDetailCommand : IRequest<string>, ICommand
    {
        public UpdateOrderDetailCommand(string orderID, string productID, int quantity, decimal productCost, decimal? goldSellCost, decimal? goldBuyCost, decimal? diamondSellCost)
        {
            OrderID = orderID;
            ProductID = productID;
            Quantity = quantity;
            ProductCost = productCost;
            GoldSellCost = goldSellCost;
            GoldBuyCost = goldBuyCost;
            DiamondSellCost = diamondSellCost;
        }
        public string Id { get; set; }
        public required string OrderID { get; set; }
        public required string ProductID { get; set; }
        public required int Quantity { get; set; }
        public required decimal ProductCost { get; set; } // TotalCost của detail
        public decimal? GoldSellCost { get; set; } // Gía bán cho customer
        public decimal? GoldBuyCost { get; set; } // Gía mua lại từ customer
        public decimal? DiamondSellCost { get; set; }
    }
}
