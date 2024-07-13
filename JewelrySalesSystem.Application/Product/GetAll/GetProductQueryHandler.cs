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
using JewelrySalesSystem.Domain.Functions;
using JewelrySalesSystem.Domain.Commons.Interfaces;

namespace JewelrySalesSystem.Application.Product.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IGoldRepository _goldRepository;
        private readonly IDiamondRepository _diamondRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ICalculator _tools;
        private readonly IGoldService _goldService;
        private readonly IDiamondService _diamondService;
        public GetProductQueryHandler(IProductRepository productRepository, IMapper mapper
            , IDiamondRepository diamondRepository
            , ICategoryRepository categoryRepository
            , IGoldRepository goldRepository
            , ICalculator tools
            , IDiamondService diamondService
            , IGoldService goldService)
        {
            _goldRepository = goldRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _diamondRepository = diamondRepository;
            _categoryRepository = categoryRepository;
            _tools = tools;
            _goldService = goldService;
            _diamondService = diamondService;
        }

        public async Task<List<ProductDto>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
            if (!product.Any())
                throw new NotFoundException("Không tìm thấy product nào");

            var goldType = await _goldRepository.FindAllToDictionaryAsync(x => x.Name != null, x => x.ID, x => x.Name, cancellationToken);
            var diamondType = await _diamondRepository.FindAllToDictionaryAsync(x => x.Name != null, x => x.ID, x => x.Name, cancellationToken);
            var category = await _categoryRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);

            var productCost = product.ToDictionary(
                x => x.ID,
                x =>
                {
                    var goldPrice = _goldService.GetGoldPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == x.Gold.Name);
                    var goldCost = goldPrice?.SellCost > 0 ? goldPrice.SellCost : goldPrice?.BuyCost;

                    var dsCost = _diamondService.GetDiamondPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == x.Diamond.Name).SellCost;
                    return _tools.CalculateSellCost(x.GoldWeight, goldCost, dsCost, x.WageCost);
                });

            return product.MapToProductDtoList(_mapper, goldType, diamondType, category, productCost);
        }
    }
}
