using JewelrySalesSystem.Application.OrderDetail.GetAll;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.GetByID
{
    public class GetByIDQueryHandler : IRequestHandler<GetByIDQuery, OrderDetailDto>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public GetByIDQueryHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<OrderDetailDto> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepository.GetOrderDetailByIdAsnyc(request.Id, cancellationToken);
            return new OrderDetailDto
            {
                ID = orderDetail.ID,
                OrderID = orderDetail.OrderID,
                ProductCost = orderDetail.ProductCost,
                ProductID = orderDetail.ProductID,
                Quantity = orderDetail.Quantity,
                DiamondSellCost = orderDetail?.DiamondSellCost,
                GoldBuyCost = orderDetail?.GoldBuyCost,
                GoldSellCost = orderDetail?.GoldSellCost,
            };
  
        }
    }

}

