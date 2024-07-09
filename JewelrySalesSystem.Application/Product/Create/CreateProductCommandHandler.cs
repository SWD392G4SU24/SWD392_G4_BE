using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Functions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using MediatR;
using Microsoft.IdentityModel.Tokens;
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
        private readonly IDiamondRepository _diamondRepository;
        private readonly IGoldRepository _goldRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateProductCommandHandler(IProductRepository productRepository
            , IDiamondRepository diamondRepository
            , IGoldRepository goldRepository
            , ICurrentUserService currentUserService
            , ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _diamondRepository = diamondRepository;
            _goldRepository = goldRepository;
            _currentUserService = currentUserService;
            _categoryRepository = categoryRepository;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {            
            var category = await _categoryRepository.FindAsync(c => c.ID == request.CategoryID && c.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Không tồn tại Category với ID: " + request.CategoryID);

            var diamond = await _diamondRepository.FindAsync(c => c.Name.Equals(request.DiamondType)
            , query => query.OrderByDescending(d => d.CreatedAt).Take(1)
            , cancellationToken);
            if (diamond == null && !request.DiamondType.IsNullOrEmpty())
            {
                throw new NotFoundException("Không tồn tại kim cương với type: " + request.DiamondType);
            }

            var gold = await _goldRepository.FindAsync(c => c.Name.Equals(request.GoldType)
            , query => query.OrderByDescending(c => c.CreatedAt).Take(1)
            , cancellationToken);
            if (gold == null && !request.GoldType.IsNullOrEmpty())
            {
                throw new NotFoundException("Không tồn tại vàng với type: " + request.GoldType);
            }

            decimal wageCost = new WageCost().CalculateWageCost(request?.GoldWeight, request?.DiamondType);

            var product = new ProductEntity
            {
                Name = request.Name,
                CategoryID = request.CategoryID,
                Quantity = request.Quantity,
                WageCost = wageCost,
                Description = request.Description,
                DiamondID = diamond?.ID,
                GoldID = gold?.ID,
                GoldWeight = request.GoldWeight ?? request.GoldWeight,
                ImageURL = request.ImageURL,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId
            };
            _productRepository.Add(product);
            return await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";

        }
    }
}
