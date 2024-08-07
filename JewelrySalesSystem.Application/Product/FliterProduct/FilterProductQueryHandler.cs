﻿using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Users;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Functions;

namespace JewelrySalesSystem.Application.Product.FliterProduct
{
    public class FilterProductQueryHandler : IRequestHandler<FilterProductQuery, PagedResult<ProductDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IDiamondRepository _diamondRepository;
        private readonly IGoldRepository _goldRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly ICalculator _tools;
        private readonly IGoldService _goldService;
        private readonly IDiamondService _diamondService;

        public FilterProductQueryHandler(IProductRepository productRepository
            , IDiamondRepository diamondRepository
            , IGoldRepository goldRepository
            , ICategoryRepository categoryRepository
            , IMapper mapper
            , ICalculator tools
            , IDiamondService diamondService
            , IGoldService goldService)
        {
            _productRepository = productRepository;
            _diamondRepository = diamondRepository;
            _goldRepository = goldRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _tools = tools;
            _goldService = goldService;
            _diamondService = diamondService;
        }

        public async Task<PagedResult<ProductDto>> Handle(FilterProductQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<ProductEntity>, IQueryable<ProductEntity>> queryOptions = query =>
            {
                if (request.CategoryID != 0)
                {
                    query = query.Where(x => x.CategoryID.Equals(request.CategoryID) && x.DeletedAt == null);
                }
                if (request.DiamondID != 0)
                {
                    query = query.Where(x => x.DiamondID.Equals(request.DiamondID));
                }
                if (request.GoldID != 0)
                {
                    query = query.Where(x => x.GoldID.Equals(request.GoldID));
                }
                if (!string.IsNullOrEmpty(request.Name))
                {
                    query = query.Where(x => x.Name.Contains(request.Name));
                }
           
                return query;
            };

            var result = await _productRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            if (!result.Any())
            {
                throw new NotFoundException("Không tìm thấy Product");
            }
            var categories = await _categoryRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);
            var diamonds = await _diamondRepository.FindAllToDictionaryAsync(x => x.CreatedAt != null, x => x.ID, x => x.Name, cancellationToken);
            var golds = await _goldRepository.FindAllToDictionaryAsync(x => x.CreatedAt != null, x => x.ID, x => x.Name, cancellationToken);
            var goldList = await _goldService.GetGoldPricesAsync(cancellationToken);
            var diamondList = await _diamondService.GetDiamondPricesAsync(cancellationToken);

            var productCost = result.ToDictionary(
                x => x.ID,
                x =>
                {                  
                    var goldPrice = goldList.FirstOrDefault(v => v.Name == x.Gold?.Name);
                    var goldCost = goldPrice?.SellCost > 0 ? goldPrice.SellCost : goldPrice?.BuyCost;
                   
                    var diamondPrice = diamondList.FirstOrDefault(v => v.Name == x.Diamond?.Name);
                    var dsCost = diamondPrice?.SellCost > 0 ? diamondPrice.SellCost : diamondPrice?.BuyCost;
                    return _tools.CalculateSellCost(x.GoldWeight, goldCost, dsCost, x.WageCost);
                });

            return PagedResult<ProductDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToProductDtoList(_mapper, golds, diamonds, categories, productCost));
        }
    }
}
