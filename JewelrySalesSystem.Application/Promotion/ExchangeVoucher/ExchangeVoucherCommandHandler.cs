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

namespace JewelrySalesSystem.Application.Promotion.ExchangeVoucher
{
    public class ExchangeVoucherCommandHandler : IRequestHandler<ExchangeVoucherCommand, string>
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly ICurrentUserService _currentUserService;

        public ExchangeVoucherCommandHandler(IPromotionRepository promotionRepository, ICurrentUserService currentUserService)
        {
            _promotionRepository = promotionRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(ExchangeVoucherCommand request, CancellationToken cancellationToken)
        {
            var promotionList = await _promotionRepository.FindAllAsync(x => x.Description == request.VoucherContent && x.UserID == null, cancellationToken);
                if (!promotionList.Any()) throw new NotFoundException("Không tìm thấy promtion nào không có User");

            var random = new Random();
            var randomPromotion = promotionList[random.Next(promotionList.Count)];

            randomPromotion.UserID = _currentUserService.UserId;
            _promotionRepository.Update(randomPromotion);
            return await _promotionRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "User đã đổi promotion thành công" : "User đã đổi promotion thất bại";

        }
    }
}
