using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
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
    public class DeleteProductQueryHandler : IRequestHandler<DeleteProductQuery, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly ICurrentUserService _currentUserService;

        public DeleteProductQueryHandler(IProductRepository productRepository, ICurrentUserService currentUserService)
        {
            _productRepository = productRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(DeleteProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsnyc(request.ID, cancellationToken);
            if (product == null) throw new NotFoundException("The ProductID :" + request.ID + "is not found");
            product.DeleterID = _currentUserService.UserId;
            product.DeletedAt = DateTime.Now;
            _productRepository.Update(product);
            await _productRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Deleted Product Successfully" ;
        }
    }
}
