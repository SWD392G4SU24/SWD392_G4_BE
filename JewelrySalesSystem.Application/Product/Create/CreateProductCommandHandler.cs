using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
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
        private readonly ICurrentUserService _currentUserService;

        public CreateProductCommandHandler(IProductRepository productRepository, ICurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var isExist = await _productRepository.FindAsync(s => s.CategoryID == request.CategoryID, cancellationToken);
            if (isExist == null)
                throw new NotFoundException ("The Category is not exist");

                isExist= await _productRepository.FindAsync(s => s.DiamonType == request.DiamonType, cancellationToken);
            if (isExist == null)
                throw new NotFoundException("The DiamonType is not exist");

                isExist= await _productRepository.FindAsync(s => s.GoldType == request.GoldType, cancellationToken);
            if (isExist == null)
                throw new NotFoundException("The GoldType is not exist");

            var product = new ProductEntity
            {
                CategoryID = request.CategoryID,
                Quantity = request.Quantity,
                WageCost = request.WageCost,
                Description = request.Description,
                DiamonType = request.DiamonType,
                GoldType = request.GoldType,
                GoldWeight = request.GoldWeight,
                ImageURL = request.ImageURL,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId
            };
            _productRepository.Add(product);   
            await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Create a product successfully with the ID: " + product.ID;
            
        }
    }
}
