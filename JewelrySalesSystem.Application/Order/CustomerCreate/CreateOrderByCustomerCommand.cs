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
        public CreateOrderByCustomerCommand(string? promotionID, List<CreateOrderDetailCommand> orderDetails)
        {
            PromotionID = promotionID;
            OrderDetails = orderDetails;
        }
        public List<CreateOrderDetailCommand> OrderDetails { get; set; }
        public string? PromotionID { get; set; }

    }
}
