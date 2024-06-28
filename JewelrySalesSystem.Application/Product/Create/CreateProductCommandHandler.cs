﻿using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGoldService  _goldService;
        private readonly IDiamondService  _diamondService;
        private readonly ICurrentUserService _currentUserService;

        public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IGoldService goldService, IDiamondService diamondService, ICurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _goldService = goldService;
            _diamondService = diamondService;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            var category = await _categoryRepository.FindAsync(c => c.ID == request.CategoryID && c.DeletedAt == null, cancellationToken);
            if (category == null) throw new NotFoundException("Category not found");

            var diamond = await _diamondService.CheckIfDiamondExistAsync(request.DiamondType, cancellationToken);
            if (!diamond) throw new NotFoundException("DiamondType not found");

            //var gold = await _goldService.CheckIfGoldExistAsync(request.GoldType, cancellationToken);
            //if (!gold) throw new NotFoundException("GoldType not found");

            var product = new ProductEntity
            {
                CategoryID = request.CategoryID,
                Quantity = request.Quantity,
                WageCost = request.WageCost,
                Description = request.Description,
                DiamonType = request.DiamondType,
                GoldType = request.GoldType,
                GoldWeight = request.GoldWeight,
                ImageURL = request.ImageURL,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId
            };
            _productRepository.Add(product);
            await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return product.ID;

        }
    }
}
