using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.OrderDetail.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.StaffCreate
{
    public class CreateOrderByStaffCommand : IRequest<string>, ICommand
    {
        public CreateOrderByStaffCommand(string buyerID, string? promotionID, int paymentMethodID, List<CreateOrderDetailCommand> orderDetails)
        {
            BuyerID = buyerID;
            PromotionID = promotionID;
            PaymentMethodID = paymentMethodID;
            OrderDetails = orderDetails;
        }
        public string BuyerID { get; set; }
        public List<CreateOrderDetailCommand> OrderDetails { get; set; }
        public string? PromotionID { get; set; }
        public int PaymentMethodID { get; set; }

    }
}
