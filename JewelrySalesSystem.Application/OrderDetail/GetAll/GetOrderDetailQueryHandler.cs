using AutoMapper;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.GetAll
{
    public class GetOrderDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, List<OrderDetailDto>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public GetOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailDto>> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderDetailRepository.FindAllAsync(cancellationToken);
            return orderDetails.MapToOrderDetailDtoList(_mapper);
        }
    }
}
