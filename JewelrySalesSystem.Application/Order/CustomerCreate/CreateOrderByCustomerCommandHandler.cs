﻿using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Functions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.CustomerCreate
{
    public class CreateOrderByCustomerCommandHandler : IRequestHandler<CreateOrderByCustomerCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IGoldService _goldService;
        private readonly IDiamondService _diamondService;
        private readonly ICalculator _tools;
        public CreateOrderByCustomerCommandHandler(IOrderRepository orderRepository
            , IOrderDetailRepository orderDetailRepository
            , IProductRepository productRepository
            , IPromotionRepository promotionRepository
            , IUserRepository userRepository
            , ICurrentUserService currentUserService
            , IPaymentMethodRepository paymentMethodRepository
            , IDiamondService diamondService
            , IGoldService goldService
            , ICalculator tools)
        {
            _goldService = goldService;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
            _promotionRepository = promotionRepository;
            _currentUserService = currentUserService;
            _paymentMethodRepository = paymentMethodRepository;
            _diamondService = diamondService;
            _tools = tools;
        }
        public async Task<string> Handle(CreateOrderByCustomerCommand command, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.FindAsync(x => x.ID == _currentUserService.UserId && x.DeleterID == null && x.Status != UserStatus.BANNED, cancellationToken);
            if (existUser == null)
            {
                throw new NotFoundException("Người dùng không tồn tại hoặc đã bị BAN");
            }
            if (existUser.Status.Equals(UserStatus.BANNED))
            {
                return "Người dùng đã bị BAN. Liên hệ admin để mở khóa tài khoản";
            }
            if (existUser.Status.Equals(UserStatus.UNVERIFIED))
            {
                return "Tài khoản chưa được xác thực";
            }

            var existPromotion = await _promotionRepository.FindAsync(x => x.ID == command.PromotionID && x.DeleterID == null, cancellationToken);
            if (existPromotion == null && !command.PromotionID.IsNullOrEmpty())
            {
                throw new NotFoundException("Không tìm thấy ưu đãi với ID: " + command.PromotionID);
            }         
            var paymentMethod = await _paymentMethodRepository.FindAsync(x => x.Name.Equals("VnPay"), cancellationToken);
            OrderEntity order = new OrderEntity 
            {
                BuyerID = existUser.ID,
                Note = existUser.ID + " thanh toán online",
                PaymentMethodID = paymentMethod.ID,
                Status = OrderStatus.PENDING,
                TotalCost = 0,
                Type = OrderType.ONLINE_ORDER,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId,
                PromotionID = command.PromotionID.IsNullOrEmpty() ? null : existPromotion.ID,                
            };

            List<OrderDetailEntity> orderDetails = new List<OrderDetailEntity>();
            foreach(var item in command.OrderDetails)
            {
                var existProduct = await _productRepository.FindAsync(x => x.ID == item.ProductID && x.DeleterID == null, cancellationToken);
                if (existProduct == null)
                {
                    throw new NotFoundException("Không tìm thấy sản phẩm với ID: " + item.ProductID);
                }
                if (existProduct.Quantity < item.Quantity)
                {
                    return "Sản phẩm trong kho không đủ";
                }

                // lấy giá vàng và giá kc ( khách hàng mua -> SellCost, 1 số loại vàng sellCost = buyCost ) mới nhất
                decimal gbCost = 0;
                decimal gsCost = 0;
                if (existProduct.GoldID != null)
                {
                    var goldService = await _goldService.GetGoldPricesAsync(cancellationToken);
                    gbCost = goldService.FirstOrDefault(v => v.Name == existProduct.Gold.Name).BuyCost;
                    gsCost = goldService.FirstOrDefault(v => v.Name == existProduct.Gold.Name).SellCost;
                }
                decimal dsCost = 0;
                if (existProduct.DiamondID != null)
                {
                    var diamondService = await _diamondService.GetDiamondPricesAsync(cancellationToken);
                    dsCost = diamondService.FirstOrDefault(v => v.Name == existProduct.Diamond.Name).SellCost;
                }

                orderDetails.Add(new OrderDetailEntity
                {
                    OrderID = order.ID,
                    ProductID = item.ProductID,
                    ProductCost = _tools.CalculateSellCost(existProduct.GoldWeight, (gsCost == 0 ? gbCost : gsCost), dsCost, existProduct.WageCost) * item.Quantity
                    /*(existProduct.WageCost + (gsCost == 0 ? gbCost : gsCost) + dsCost) * item.Quantity*/,
                    GoldBuyCost = existProduct.GoldID != null ? gbCost : null,
                    GoldSellCost = existProduct.GoldID != null ? gsCost : null,
                    DiamondSellCost = existProduct.DiamondID != null ? dsCost : null,
                    Quantity = item.Quantity,
                    CreatedAt = DateTime.Now,
                    CreatorID = _currentUserService.UserId,
                });               
            }
            _orderRepository.Add(order);

            foreach (var orderDetail in orderDetails)
            {
                _orderDetailRepository.Add(orderDetail);
                order.TotalCost += orderDetail.ProductCost;
            }

            if (existPromotion != null)
            {
                // check xem sử dụng được promotion không
                if (order.TotalCost < existPromotion.ConditionsOfUse)
                {
                    return "Không đủ điều kiện sử dụng ưu đãi";
                }
                if (existPromotion.Status != PromotionStatus.AVAILABLE)
                {
                    return "Ưu đãi không thể sử dụng";
                }
                // cập nhật lại giá tiền order
                if (order.TotalCost * (decimal)existPromotion.ReducedPercent / 100 > existPromotion.ConditionsOfUse)
                {
                    order.TotalCost -= existPromotion.MaximumReduce;
                }
                else
                {
                    order.TotalCost -= order.TotalCost * (decimal)existPromotion.ReducedPercent / 100;
                }
            }

            return await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? order.ID : "Tạo thất bại";
        }
    }
}
