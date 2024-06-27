using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product.Delete
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteProductCommandHandler(IProductRepository productRepository, ICurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.FindAsync(s => s.ID == request.ID && s.DeletedAt == null, cancellationToken);
            if (product is null) throw new NotFoundException("Product is not exist");
            product.DeleterID = _currentUserService.UserId;
            product.DeletedAt = DateTime.Now;
            _productRepository.Update(product);
            return await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken) == 1 ? "Deleted Product Successfully" : "Delete Product Failed" ;
        }
    }
}
