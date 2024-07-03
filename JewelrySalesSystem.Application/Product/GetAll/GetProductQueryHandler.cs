using JewelrySalesSystem.Application.Promotion.GetAll;
using JewelrySalesSystem.Application.Promotion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelrySalesSystem.Domain.Repositories;
using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Exceptions;

namespace JewelrySalesSystem.Application.Product.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAllAsync(x => x.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Không tìm thấy product nào");
            return product.MapToProductDtoList(_mapper);
        }
    }
}
