using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.GetAll
{
    public class GetAllOrderDetailQueryHandler : IRequestHandler<GetAllOrderDetailQuery, List<OrderDetailDto>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetAllOrderDetailQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper, IProductRepository productRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<OrderDetailDto>> Handle(GetAllOrderDetailQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderDetailRepository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
             if (!orderDetails.Any()) throw new NotFoundException("Không tìm thấy OrderDetail nào");
            var productNames = await _productRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);
            var productImgUrl = await _productRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.ImageURL, cancellationToken);

            return orderDetails.MapToOrderDetailDtoList(_mapper, productNames, productImgUrl);
        }
    }
}
