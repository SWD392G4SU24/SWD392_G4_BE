using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail
{
    public class OrderDetailDto : IMapFrom<OrderDetailEntity>
    {
        public OrderDetailDto()
        {
            
        }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderDetailEntity, OrderDetailDto>();
        }
        public string ID { get; set; }
        public string OrderID { get; set; }
        public string ProductID { get; set; }
        public string Product {  get; set; }
        public string? ProductImgUrl {  get; set; }
        public int Quantity { get; set; }
        public decimal ProductCost { get; set; } // TotalCost của detail
        public decimal? GoldSellCost { get; set; } // Gía bán cho customer
        public decimal? GoldBuyCost { get; set; } // Gía mua lại từ customer
        public decimal? DiamondSellCost { get; set; }

        public OrderDetailDto(string id, string orderID, string productID, string product, string productImgUrl, int quantity
            , decimal productCost, decimal? goldSellCost, decimal? diamondSellCost)
        {
            ID = id;
            OrderID = orderID;
            ProductID = productID;
            Product = product;
            ProductImgUrl = productImgUrl;
            Quantity = quantity;
            ProductCost = productCost;
            GoldSellCost = goldSellCost;
            DiamondSellCost = diamondSellCost;
        }
    }
}
