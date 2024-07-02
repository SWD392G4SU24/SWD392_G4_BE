﻿using JewelrySalesSystem.Application.Common.Interfaces;
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
            var product = await _productRepository.FindAsync(s => s.ID == request.ID && s.DeletedAt == null, cancellationToken);
            if (product is null) throw new NotFoundException("Product không tồn tại");
            // Update specific fields based on request properties
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
            return await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken) == 1 ? "Cập nhật product thành công" : "Cập nhật product thất bại";
        }

      
    }
}
