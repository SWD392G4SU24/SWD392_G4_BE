using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Users.CreateNewUser;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

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
                Description = request.Description.IsNullOrEmpty() ? null : request.Description,
                ExpiresTime = request.ExpiresTime,
                MaximumReduce = request.MaximumReduce,
                ReducedPercent = request.ReducedPercent,
                UserID = null,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId,
                Status = PromotionStatus.UNAVAILABLE
            };
            _promotionRepository.Add(promotion);
            return await _promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? promotion.ID : "tạo thất bại";
        }
    }
}
