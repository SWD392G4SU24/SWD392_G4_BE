using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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
        private readonly ICurrentUserService _currentUserService;

        public UpdatePromotionCommandHandler(IPromotionRepository promotionRepository, ICurrentUserService currentUserService)
        {
            _promotionRepository = promotionRepository;
            _currentUserService = currentUserService;   
        }

        public async Task<string> Handle(UpdatePromotionCommand request, CancellationToken cancellationToken)
        {
            var promotion = await _promotionRepository.FindAsync(s => s.ID == request.ID, cancellationToken);
            if (promotion is null) throw new NotFoundException("Promotion is not exist");
            // Update specific fields based on request properties
            promotion.ConditionsOfUse = request.ConditionsOfUse;
            promotion.Description = request.Description ?? request.Description;
            promotion.ReducedPercent = request.ReducedPercent;
            promotion.ExpiresTime = request.ExpiresTime;
            promotion.ExchangePoint = request.ExchangePoint;
            promotion.MaximumReduce = request.MaximumReduce;
            promotion.UpdaterID = _currentUserService.UserId;
            promotion.LastestUpdateAt = DateTime.Now;
            _promotionRepository.Update(promotion);
            await _promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Promotion Updated Successfully";
        }

 
    }
}
