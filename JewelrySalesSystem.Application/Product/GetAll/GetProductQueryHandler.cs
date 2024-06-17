using JewelrySalesSystem.Application.Promotion.GetAll;
using JewelrySalesSystem.Application.Promotion;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelrySalesSystem.Domain.Repositories;

namespace JewelrySalesSystem.Application.Product.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAllProductsAsync(cancellationToken);
            return product.Select(s => new ProductDto
            {
                Id = s.ID,
                CategoryID = s.CategoryID,
                Quantity = s.Quantity,
                WageCost = s.WageCost,
                Description = s.Description,
                DiamonType = s.DiamonType,
                GoldType = s.GoldType,
                GoldWeight = s.GoldWeight,
                ImageURL = s.ImageURL,
            }).ToList();
        }
    }
}
