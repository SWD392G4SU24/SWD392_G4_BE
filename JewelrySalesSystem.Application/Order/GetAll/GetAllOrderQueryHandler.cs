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

namespace JewelrySalesSystem.Application.Order.GetAll
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var repostList = await _orderRepository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
            if(!repostList.Any()) throw new NotFoundException("Không tìm thấy order nào !!");
            return repostList.MapToOrderDtoList(_mapper);
        }
    }
}
