using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Promotion.GetById;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.DeletePromotion
{
    public class DeletePromotionQueryHandler : IRequestHandler<DeletePromotionQuery, string>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeletePromotionQueryHandler(IPromotionRepository promotionRepository, ICurrentUserService currentUserService)
        {
            _promotionRepository = promotionRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeletePromotionQuery request, CancellationToken cancellationToken)
        {
            // Logic to retrieve promotions base on query parameters(if any)
            var promotions = await _promotionRepository.GetPromotionByIdAsnyc(request.ID, cancellationToken);
            if (promotions is null) throw new NotFoundException("The VoucherCode: " + request.ID + " is not found");
            promotions.DeleterID = _currentUserService.UserId;
            promotions.DeletedAt = DateTime.Now;
            _promotionRepository.Update(promotions);
            await _promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Promotion Deleted Successfully";
        }
    }
}
