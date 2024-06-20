using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.GetAll
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, IEnumerable<OrderDetailDto>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public GetOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<IEnumerable<OrderDetailDto>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderDetailRepository.FindAllAsync(cancellationToken);
            return orderDetails.Select(s => new OrderDetailDto
            {
                ID = s.ID,
                OrderID = s.OrderID,
                ProductCost = s.ProductCost,
                ProductID = s.ProductID,
                Quantity = s.Quantity,
                DiamondSellCost = s.DiamondSellCost,
                GoldBuyCost = s.GoldBuyCost,
                GoldSellCost = s.GoldSellCost,
            }).ToList();
        }
    }
}
