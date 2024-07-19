using Castle.Core.Resource;
using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Promotion.ExchangeVoucher
{
    public class ExchangeVoucherCommandHandler : IRequestHandler<ExchangeVoucherCommand, string>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;

        public ExchangeVoucherCommandHandler(IPromotionRepository promotionRepository
            , ICurrentUserService currentUserService
            , IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _promotionRepository = promotionRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(ExchangeVoucherCommand request, CancellationToken cancellationToken)
        {
            var promotionList = await _promotionRepository.FindAllAsync(x => x.Description == request.VoucherContent && x.UserID == null, cancellationToken);
            if (!promotionList.Any()) throw new NotFoundException("Không còn ưu đãi nào");
            var user = await _userRepository.FindAsync(x => x.ID.Equals(_currentUserService.UserId) && x.DeletedAt == null, cancellationToken);
            if (user == null)
            {
                throw new NotFoundException("Không tìm thấy tài khoản");
            }
            if (user.Status.Equals(UserStatus.BANNED))
            {
                return "Tài khoản người dùng đã bị BAN. Liên hệ Admin để mở khóa";
            }
            if (user.Status.Equals(UserStatus.UNVERIFIED))
            {
                return "Tài khoản người dùng chưa được xác thực";
            }
            var randomPromotion = promotionList.First();           
            randomPromotion.UserID = _currentUserService.UserId;
            randomPromotion.LastestUpdateAt = DateTime.UtcNow;
            randomPromotion.UpdaterID = _currentUserService.UserId;
            user.Point -= randomPromotion.ExchangePoint;
            user.LastestUpdateAt = DateTime.UtcNow;
            user.UpdaterID = _currentUserService.UserId;
            
            _promotionRepository.Update(randomPromotion);
            _userRepository.Update(user);
            return await _promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Đổi ưu đãi thành công" : "Đổi ưu đãi thất bại";

        }
    }
}
