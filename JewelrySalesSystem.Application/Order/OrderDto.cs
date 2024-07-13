using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;
using System.Text.Json.Serialization;

namespace JewelrySalesSystem.Application.Order
{
    public class OrderDto : IMapFrom<OrderEntity>
    {
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderEntity, OrderDto>();
        }
        public string ID {  get; set; }
        public string Note { get; set; }
        public string Type { get; set; }
        public string Status {  get; set; }
        public decimal TotalCost { get; set; }
        public string? PromotionID { get; set; }
        public int? CounterID { get; set; }
        public string? Counter {  get; set; }
        public string BuyerID { get; set; }
        public string FullName {  get; set; }
        public int PaymentMethodID { get; set; }
        public string PaymentMethod {  get; set; }
        public OrderDto(string id, string note, string type, string status, decimal totalCost, string? promotionID
            , int? counterID, string? counter, string buyerID, string fullName, int paymentMethodID, string paymentMethod)
        {
            ID = id;
            Note = note;
            Type = type;
            Status = status;
            TotalCost = totalCost;
            PromotionID = promotionID;
            CounterID = counterID;
            Counter = counter;
            BuyerID = buyerID;
            FullName = fullName;
            PaymentMethodID = paymentMethodID;
            PaymentMethod = paymentMethod;
        }

        public OrderDto()
        {
            
        }
    }
}
