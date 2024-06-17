using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Users.CreateNewUser;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.CreatePromotion
{
   
    public class CreatePromotionCommandHandler : IRequestHandler<CreatePromtionCommand, string>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly ICurrentUserService _currentUserService;
        public CreatePromotionCommandHandler(IPromotionRepository promotionRepository, ICurrentUserService currentUserService)
        {
            _promotionRepository = promotionRepository;
            _currentUserService = currentUserService;
        }
 

        public async Task<string> Handle(CreatePromtionCommand request, CancellationToken cancellationToken)
        {
            var promotion = new PromotionEntity
            {
                ConditionsOfUse = request.ConditionsOfUse,
                ExchangePoint = request.ExchangePoint,
                ExpiresTime = request.ExpiresTime.AddDays(+30),
                MaximumReduce = request.MaximumReduce,
                ReducedPercent = request.ReducedPercent,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId
            };
            _promotionRepository.Add(promotion);
            await _promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return promotion.ID;
        }
    }
}
