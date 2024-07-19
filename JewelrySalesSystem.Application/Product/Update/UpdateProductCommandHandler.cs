using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Functions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IDiamondRepository _diamondRepository;
        private readonly IGoldRepository _goldRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICalculator _tools;

        public UpdateProductCommandHandler(IProductRepository productRepository
            , IDiamondRepository diamondRepository
            , IGoldRepository goldRepository
            , ICurrentUserService currentUserService
            , ICategoryRepository categoryRepository
            , ICalculator tools)
        {
            _productRepository = productRepository;
            _diamondRepository = diamondRepository;
            _goldRepository = goldRepository;
            _currentUserService = currentUserService;
            _categoryRepository = categoryRepository;
            _tools = tools;
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.FindAsync(c => c.ID == request.CategoryID && c.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Category không tồn tại");

            var product = await _productRepository.FindAsync(s => s.ID == request.ID && s.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Product không tồn tại");

            var diamond = await _diamondRepository.FindAsync(c => c.Name.Equals(request.DiamondType) && request.DiamondType != null
            , query => query.OrderByDescending(d => d.CreatedAt).Take(1)
            , cancellationToken);
            if (diamond == null && !request.DiamondType.IsNullOrEmpty())
            {
                throw new NotFoundException("Không tồn tại kim cương với type: " + request.DiamondType);
            }

            var gold = await _goldRepository.FindAsync(c => c.Name.Equals(request.GoldType) && request.GoldType != null
            , query => query.OrderByDescending(c => c.CreatedAt).Take(1)
            , cancellationToken);
            if (gold == null && !request.GoldType.IsNullOrEmpty())
            {
                throw new NotFoundException("Không tồn tại vàng với type: " + request.GoldType);
            }

            //Caculate wageCost
            decimal wageCost = 0;
            if (diamond != null && gold != null)
            {
                wageCost = _tools.CalculateWageCost(request.GoldWeight, diamond.Name);
            }
            else if (gold != null && diamond == null)
            {
                wageCost = _tools.CalculateWageCost(request.GoldWeight, product.Diamond?.Name);
            }
            else if (gold == null && diamond != null)
            {
                wageCost = _tools.CalculateWageCost(request?.GoldWeight, diamond.Name);
            }           

            // Update specific fields based on request properties
            product.Name = request.Name ?? product.Name;
            product.CategoryID = request.CategoryID ?? product.CategoryID;
            product.WageCost = wageCost == 0 ? product.WageCost : wageCost;
            product.Quantity = request.Quantity ?? product.Quantity;
            product.GoldWeight = request.GoldWeight ?? product.GoldWeight;
            product.Description = request.Description ?? product.Description;
            product.GoldID = gold == null ? product.GoldID : gold.ID;
            product.DiamondID = diamond == null ? product.GoldID : diamond.ID;
            product.ImageURL = request.ImageURL ?? product.ImageURL;
            product.UpdaterID = _currentUserService.UserId;
            product.LastestUpdateAt = DateTime.Now;
            _productRepository.Update(product);
            return await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }

      
    }
}
