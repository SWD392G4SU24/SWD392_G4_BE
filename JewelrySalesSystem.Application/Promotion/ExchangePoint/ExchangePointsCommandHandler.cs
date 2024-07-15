﻿
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

        public ExchangePointsCommandHandler(IPromotionRepository promotionRepository, IUserRepository userRepository)
        {
            _promotionRepository = promotionRepository;
            _userRepository = userRepository;
        }

        public async Task<string> Handle(ExchangePointsCommand request, CancellationToken cancellationToken)
        {
            var customer = await _userRepository.FindAsync(x => x.ID == request.CustomerID && x.DeletedAt == null, cancellationToken)
                  ?? throw new NotFoundException("Không tìm thấy Customer nào!");


            var promotion = await _promotionRepository.FindAsync(x => x.ID == request.VoucherCode && x.DeletedAt == null, cancellationToken)
                  ?? throw new NotFoundException("Không tìm thấy promotion nào!");


            if (promotion.ExchangePoint > customer.Point) return "Bạn không đủ điểm để đổi thưởng";

            promotion.UserID = request.CustomerID;
            promotion.Status = PromotionStatus.AVAILABLE;
            customer.Point -= promotion.ExchangePoint;
            _promotionRepository.Update(promotion);
            _userRepository.Update(customer);
            return await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Đổi điểm thành voucher thành công" : "Đổi điểm thành voucher thất bại";


        }
    }
}
