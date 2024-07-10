using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.OrderDetail.Create;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.CustomerCreate
{
    public class CreateOrderByCustomerCommand : IRequest<string>, ICommand
    {
        public CreateOrderByCustomerCommand(string buyerID, string? promotionID, int paymentMethodID, List<CreateOrderDetailCommand> orderDetails)
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
