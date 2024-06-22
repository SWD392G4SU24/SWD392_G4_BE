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

        public GetByIDQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAsync(s => s.ID == request.ID, cancellationToken);
            if (product is null) throw new NotFoundException("Product is not exist");
            return new ProductDto
            {
                Id = product.ID,
                CategoryID = product.CategoryID,
                Quantity = product.Quantity,
                WageCost = product.WageCost,
                Description = product.Description,
                DiamonType = product.DiamonType,
                GoldType = product.GoldType,
                GoldWeight = product.GoldWeight,
                ImageURL = product.ImageURL,
            };
        }
    }
}
