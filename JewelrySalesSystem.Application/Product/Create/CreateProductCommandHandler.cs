using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Functions;
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
        //private readonly ICategoryRepository _categoryRepository;
        private readonly IDiamondRepository _diamondRepository;
        private readonly IGoldRepository _goldRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateProductCommandHandler(IProductRepository productRepository, IDiamondRepository diamondRepository, IGoldRepository goldRepository, ICurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _diamondRepository = diamondRepository;
            _goldRepository = goldRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {

            //var category = await _categoryRepository.FindAsync(c => c.ID == request.CategoryID && c.DeletedAt == null, cancellationToken)
            //    ?? throw new NotFoundException("Category không tồn tại");
            var diamondList = await _diamondRepository.FindAllAsync(cancellationToken);

            var diamond = await _diamondRepository.FindAsync(c => c.ID == request.DiamondType, cancellationToken)
                ?? throw new NotFoundException("Diamond không tồn tại");
          
            var gold = await _goldRepository.FindAsync(c => c.ID == request.GoldType, cancellationToken)
                ?? throw new NotFoundException("Gold không tồn tại");

            //Caculate wageCost
            decimal wageCost = WageCost.CalculateWageCost
                (
                    request.Quantity,
                    request.GoldWeight,
                    diamond.Name
                );

            var product = new ProductEntity
            {
                CategoryID = request.CategoryID,
                Quantity = request.Quantity,
                WageCost = wageCost,
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
