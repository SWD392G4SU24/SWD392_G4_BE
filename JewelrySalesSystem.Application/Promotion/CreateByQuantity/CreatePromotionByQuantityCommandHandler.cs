using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Promotion.NewFolder;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Promotion.CreateByQuantity
{
    public class CreatePromotionByQuantityCommandHandler : IRequestHandler<CreatePromotionByQuantityCommand, List<string>>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreatePromotionByQuantityCommandHandler(IPromotionRepository promotionRepository, ICurrentUserService currentUserService, IUserRepository userRepository)
        {
            _promotionRepository = promotionRepository;
            _currentUserService = currentUserService;
            _userRepository = userRepository;
        }

        public async Task<List<string>> Handle(CreatePromotionByQuantityCommand request, CancellationToken cancellationToken)
        {
         
            List<string> promotionIds = new List<string>();

            for (int i = 0; i < request.Quantity; i++)
            {
                var promotionEntity = new PromotionEntity
                {
                    ConditionsOfUse = request.ConditionsOfUse,
                    Description = request.Description == "NULL" ? null : request.Description,
                    ExchangePoint = request.ExchangePoint,
                    ExpiresTime = request.ExpiresTime,
                    MaximumReduce = request.MaximumReduce,
                    ReducedPercent = request.ReducedPercent,
                    UserID = null,
                    CreatedAt = DateTime.Now,
                    CreatorID = _currentUserService.UserId,
                    Status = PromotionStatus.UNAVAILABLE
                };
                _promotionRepository.Add(promotionEntity);              
                promotionIds.Add(promotionEntity.ID);
            }
            await _promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return promotionIds;
        }
    }
}
