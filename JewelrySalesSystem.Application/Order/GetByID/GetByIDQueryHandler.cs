
using AutoMapper;
using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.GetByID
{
    public class GetByIDQueryHandler : IRequestHandler<GetByIDQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetByIDQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderDto> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {

            var order = await _orderRepository.FindAsync(s => s.ID == request.Id, cancellationToken)
                ?? throw new NotFoundException("Order không tồn tại");
            return order.MapToOrderDto(_mapper);

        }
    }
}
