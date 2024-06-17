using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
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
        private readonly ICurrentUserService _currentUserService;

        public UpdateProductCommandHandler(IProductRepository productRepository, ICurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsnyc(request.ID, cancellationToken);
            if (product is null) throw new NotFoundException ("The ProductID: " + request.ID + "is not found");
            product.CategoryID = request.CategoryID;
            product.WageCost = request.WageCost;
            product.Quantity = request.Quantity;
            product.GoldWeight = request.GoldWeight;
            product.Description = request.Description;
            product.GoldType = request.GoldType;
            product.DiamonType = request.DiamonType;
            product.ImageURL = request.ImageURL;
            product.UpdaterID = _currentUserService.UserId;
            product.LastestUpdateAt = DateTime.Now;
            _productRepository.Update(product);
            await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Updated Product Successfully";
        }

      
    }
}
