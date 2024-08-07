﻿using AutoMapper;
using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Functions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product.GetByID
{
    public class GetByProductIDQueryHandler : IRequestHandler<GetProductByIDQuery, ProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IGoldRepository _goldRepository;
        private readonly IDiamondRepository _diamondRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICalculator _tools;
        private readonly IGoldService _goldService;
        private readonly IDiamondService _diamondService;
        public GetByProductIDQueryHandler(IProductRepository productRepository, IMapper mapper
            , IDiamondRepository diamondRepository
            , IGoldRepository goldRepository
            , ICategoryRepository categoryRepository
            , ICalculator tools
            , IDiamondService diamondService
            , IGoldService goldService)
        {
            _categoryRepository = categoryRepository;
            _diamondRepository = diamondRepository;
            _goldRepository = goldRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _tools = tools;
            _goldService = goldService;
            _diamondService = diamondService;
        }

        public async Task<ProductDto> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAsync(s => s.ID == request.ID && s.DeletedAt == null, cancellationToken);
            if (product == null)
            {
                throw new NotFoundException("Product is not exist");
            }
                
            var goldType = product.GoldID.HasValue ? await _goldRepository.FindAsync(x => x.ID == product.GoldID, cancellationToken) : null;
            var diamondType = product.DiamondID.HasValue ? await _diamondRepository.FindAsync(x => x.ID == product.DiamondID, cancellationToken) : null;
            var category = await _categoryRepository.FindAsync(x => x.ID == product.CategoryID && x.DeletedAt == null, cancellationToken);
            if (category == null)
            {
                throw new NotFoundException("Category is not exist");
            }

            var gService = await _goldService.GetGoldPricesAsync(cancellationToken);
            var goldPrice = gService.FirstOrDefault(v => v.Name == product.Gold?.Name);
            var goldCost = goldPrice?.SellCost > 0 ? goldPrice.SellCost : goldPrice?.BuyCost;

            var dService = await _diamondService.GetDiamondPricesAsync(cancellationToken);
            var diamondPrice = dService.FirstOrDefault(v => v.Name == product.Diamond?.Name);
            var dsCost = diamondPrice?.SellCost > 0 ? diamondPrice.SellCost : diamondPrice?.BuyCost;
            
            var productCost = _tools.CalculateSellCost(product.GoldWeight, goldCost, dsCost, product.WageCost);
            
            return product.MapToProductDto(_mapper, goldType?.Name, diamondType?.Name, category.Name, productCost);
        }
    }
}
