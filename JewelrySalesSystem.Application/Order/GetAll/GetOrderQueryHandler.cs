using AutoMapper;
using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.GetAll
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var listOrder = await _orderRepository.FindAllAsync(cancellationToken);
            return listOrder.MapToOrderDtoList(_mapper);
        }
    }
}
