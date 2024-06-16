using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.UpdatePromotion
{
    public class UpdatePromotionCommandHandler : IRequestHandler<UpdatePromotionCommand, string>
    {
        private readonly IPromotionRepository _promotionRepository;
        public async Task<string> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.GetPromotionByIdAsnyc(request.ID, cancellationToken) ?? throw new NotFoundException("VoucherCode is not exist");
            // Update specific fields based on request properties
            promotion.ConditionsOfUse = request.ConditionsOfUse;
            promotion.Description = request.Description ?? request.Description;
            promotion.ReducedPercent = request.ReducedPercent;
            promotion.ExpiresTime = request.ExpiresTime;
            promotion.ExchangePoint = request.ExchangePoint;
            promotion.MaximumReduce = request.MaximumReduce;
            _promotionRepository.Update(promotion);
            return await _promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken) == 1 ? "Update Successfully" : "Update Failed";

        }

 
    }
}
