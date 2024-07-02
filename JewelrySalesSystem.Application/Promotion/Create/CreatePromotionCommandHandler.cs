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
            if (request.UserID != "NULL")
            {
                var isExist = await _promotionRepository.FindAsync(s => s.UserID == request.UserID && s.DeletedAt == null, cancellationToken)
               ?? throw new NotFoundException("The User không tồn tại");
            }

            var promotion = new PromotionEntity
            {
                ConditionsOfUse = request.ConditionsOfUse,
                ExchangePoint = request.ExchangePoint,
                Description = request.Description == "NULL" ? null : "NULL",
                ExpiresTime = request.ExpiresTime,
                MaximumReduce = request.MaximumReduce,
                ReducedPercent = request.ReducedPercent,
                UserID = request.UserID == "NULL" ? null : "NULL",
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId,
                Status = PromotionStatus.UNAVAILABLE
            };
            _promotionRepository.Add(promotion);
            await _promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return promotion.ID;
        }
    }
}
