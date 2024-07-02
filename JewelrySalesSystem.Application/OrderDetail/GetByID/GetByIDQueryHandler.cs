using AutoMapper;
using JewelrySalesSystem.Application.OrderDetail.GetAll;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
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
        private readonly IMapper _mapper;

        public GetByIDQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<OrderDetailDto> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            var orderDetail = await _orderDetailRepository.FindAsync(s => s.ID == request.Id, cancellationToken)
                ?? throw new NotFoundException("OrderDetail không tồi tại");
            return orderDetail.MapToOrderDetailDto(_mapper);

        }
    }

}

