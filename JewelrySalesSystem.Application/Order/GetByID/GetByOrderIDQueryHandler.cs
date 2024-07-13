
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
    public class GetByOrderIDQueryHandler : IRequestHandler<GetByOrderIDQuery, OrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetByOrderIDQueryHandler(IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<OrderDto> Handle(GetByOrderIDQuery request, CancellationToken cancellationToken)
        {

            var order = await _orderRepository.FindAsync(s => s.ID == request.Id && s.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Order không tồn tại");
            var productNames = await _productRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);
            var productImgUrl = await _productRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.ImageURL, cancellationToken);

            return order.MapToOrderDto(_mapper, order.Counter?.Name, order.User.FullName, order.PaymentMethod.Name, productNames, productImgUrl);

        }
    }
}
