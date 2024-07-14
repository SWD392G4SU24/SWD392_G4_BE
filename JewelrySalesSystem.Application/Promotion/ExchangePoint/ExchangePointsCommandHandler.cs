
using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Promotion.ExchangePoint
{
    public class ExchangePointsCommandHandler : IRequestHandler<ExchangePointsCommand, string>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICurrentUserService _currentUserService;

        public ExchangePointsCommandHandler(IPromotionRepository promotionRepository
            , IUserRepository userRepository
            , ICurrentUserService currentUserService)
        {
            _promotionRepository = promotionRepository;
            _userRepository = userRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(ExchangePointsCommand request, CancellationToken cancellationToken)
        {
            var customer = await _userRepository.FindAsync(x => x.ID == request.CustomerID && x.DeletedAt == null, cancellationToken)
                  ?? throw new NotFoundException("Không tìm thấy Customer nào!");

            var promotion = await _promotionRepository.FindAsync(x => x.ID == request.VoucherCode && x.DeletedAt == null, cancellationToken)
                  ?? throw new NotFoundException("Không tìm thấy promotion nào!");

            if (promotion.ExchangePoint > customer.Point) 
                return "Bạn không đủ điểm để đổi thưởng";

            if (promotion.ExpiresTime < DateTime.Now)
                return "Ưu đãi đã hết hạn";

            promotion.UserID = customer.ID;
            promotion.Status = PromotionStatus.AVAILABLE;
            promotion.LastestUpdateAt = DateTime.Now;
            promotion.UpdaterID = _currentUserService.UserId;

            customer.Point -= promotion.ExchangePoint;
            customer.UpdaterID = _currentUserService.UserId;
            customer.LastestUpdateAt = DateTime.Now;
            _promotionRepository.Update(promotion);
            _userRepository.Update(customer);
            return await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Đổi điểm thành voucher thành công" : "Đổi điểm thành voucher thất bại";


        }
    }
}
