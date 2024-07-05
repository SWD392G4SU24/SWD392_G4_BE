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
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;

namespace JewelrySalesSystem.Application.Product.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IGoldRepository _goldRepository;
        private readonly IDiamondRepository _diamondRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper
            , IDiamondRepository diamondRepository
            , ICategoryRepository categoryRepository
            , IGoldRepository goldRepository)
        {
            _goldRepository = goldRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _diamondRepository = diamondRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAllAsync(x => x.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Không tìm thấy product nào");

            var goldType = await _goldRepository.FindAllToDictionaryAsync(x => x.Name != null, x => x.ID, x => x.Name, cancellationToken);
            var diamondType = await _diamondRepository.FindAllToDictionaryAsync(x => x.Name != null, x => x.ID, x => x.Name, cancellationToken);
            var category = await _categoryRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);

            return product.MapToProductDtoList(_mapper, goldType, diamondType, category);
        }
    }
}
