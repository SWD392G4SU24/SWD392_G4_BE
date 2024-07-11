using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.OrderDetail.UpdateOrderDetail;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<string>, ICommand
    { 
        public UpdateOrderCommand(string id, string? promotionID, List<UpdateOrderDetailCommand> orderDetails)
        {
            ID = id;
            PromotionID = promotionID;
            OrderDetails = orderDetails;
        }
        public string ID { get; set; }
        public string? PromotionID { get; set; }
        public List<UpdateOrderDetailCommand> OrderDetails { get; set; }
    }
}
