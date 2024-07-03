using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Functions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
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
        private readonly IDiamondRepository _diamondRepository;
        private readonly IGoldRepository _goldRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateProductCommandHandler(IProductRepository productRepository, IDiamondRepository diamondRepository, IGoldRepository goldRepository, ICurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _diamondRepository = diamondRepository;
            _goldRepository = goldRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            //categoryEntity đức anh làm, nên tui thêm để tượng trưng là có checkExist r
            //var category = await _categoryRepository.FindAsync(c => c.ID == request.CategoryID && c.DeletedAt == null, cancellationToken)
            //    ?? throw new NotFoundException("Category không tồn tại");

            var product = await _productRepository.FindAsync(s => s.ID == request.ID && s.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Product không tồn tại");

            var diamond = await _diamondRepository.FindAsync(c => c.ID == request.DiamonType, cancellationToken)
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
            // Update specific fields based on request properties
            product.CategoryID = request.CategoryID;
            product.WageCost = wageCost;
            product.Quantity = request.Quantity;
            product.GoldWeight = request.GoldWeight ?? request.GoldWeight;
            product.Description = request.Description == "NULL" ? null : request.Description;
            product.GoldType = request.GoldType ?? request.GoldType ;
            product.DiamonType = request.DiamonType ?? request.DiamonType;
            product.ImageURL = request.ImageURL == "NULL" ? null : request.ImageURL;
            product.UpdaterID = _currentUserService.UserId;
            product.LastestUpdateAt = DateTime.Now;
            _productRepository.Update(product);
            return await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật product thành công" : "Cập nhật product thất bại";
        }

      
    }
}
