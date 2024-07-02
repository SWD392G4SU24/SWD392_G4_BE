using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Promotion.GetById;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.DeletePromotion
{
    public class DeletePromotionCommandHandler : IRequestHandler<DeletePromotionCommand, string>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly ICurrentUserService _currentUserService;
        public DeletePromotionCommandHandler(IPromotionRepository promotionRepository, ICurrentUserService currentUserService)
        {
            _promotionRepository = promotionRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(DeletePromotionCommand request, CancellationToken cancellationToken)
        {
            // Logic to retrieve promotions base on query parameters(if any)
            var promotion = await _promotionRepository.FindAsync(s => s.ID == request.ID && s.DeletedAt == null, cancellationToken)
                ?? throw new NotFoundException("Promotion không tồn tại");

            promotion.DeleterID = _currentUserService.UserId;
            promotion.DeletedAt = DateTime.Now;
            _promotionRepository.Update(promotion);
            return await _promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Xóa Promotion thành công" : "Xóa Promotion thất bại";
        }
    }
}
