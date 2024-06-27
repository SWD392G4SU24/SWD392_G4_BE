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

namespace JewelrySalesSystem.Application.Product.GetByID
{
    public class GetByIDQueryHandler : IRequestHandler<GetByIDQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetByIDQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAsync(s => s.ID == request.ID, cancellationToken);
            if (product is null) throw new NotFoundException("Product is not exist");
            return product.MapToProductDto(_mapper);
        }
    }
}
