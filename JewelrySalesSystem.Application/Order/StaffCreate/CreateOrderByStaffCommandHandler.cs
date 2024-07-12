﻿using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.VnPayModel;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace JewelrySalesSystem.Application.Order.StaffCreate
{
    public class CreateOrderByStaffCommandHandler : IRequestHandler<CreateOrderByStaffCommand, string>
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly IGoldService _goldService;
        private readonly IDiamondService _diamondService;
        private readonly IUserRepository _userRepository;
        private readonly IVnPayService _vnPayService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICounterRepository _counterRepository;


        public CreateOrderByStaffCommandHandler(ICurrentUserService currentUserService
            , IProductRepository productRepository
            , IOrderDetailRepository orderDetailRepository
            , IOrderRepository orderRepository
            , IPromotionRepository promotionRepository
            , IPaymentMethodRepository paymentMethodRepository
            , IGoldService goldService
            , IDiamondService diamondService
            , IUserRepository userRepository
            , IVnPayService vnPayService
            , IHttpContextAccessor httpContextAccessor
            , ICounterRepository counterRepository)
        {
            _currentUserService = currentUserService;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _promotionRepository = promotionRepository;
            _goldService = goldService;
            _diamondService = diamondService;
            _userRepository = userRepository;
            _vnPayService = vnPayService;
            _httpContextAccessor = httpContextAccessor;
            _counterRepository = counterRepository;
        }
        public async Task<string> Handle(CreateOrderByStaffCommand command, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.AnyAsync(x => x.ID == command.BuyerID && x.DeleterID == null, cancellationToken);
            if (!existUser)
            {
                throw new NotFoundException("Không tìm thấy người mua với ID: " + command.BuyerID);
            }

            var existMethod = await _paymentMethodRepository.FindAsync(x => x.ID == command.PaymentMethodID && x.DeleterID == null, cancellationToken);
            if (existMethod == null)
            {
                throw new NotFoundException("Không tìm thấy phương thức thanh toán với ID: " + command.PaymentMethodID);
            }

            var existPromotion = await _promotionRepository.FindAsync(x => x.ID == command.PromotionID && x.DeleterID == null, cancellationToken);
            if (existPromotion == null && !command.PromotionID.IsNullOrEmpty())
            {
                throw new NotFoundException("Không tìm thấy ưu đãi với ID: " + command.PromotionID);
            }

            var staff = await _userRepository.FindAsync(x => x.ID == _currentUserService.UserId && x.DeletedAt == null, cancellationToken);
            if (staff == null || staff.Status == UserStatus.BANNED)
            {
                throw new NotFoundException("Staff không tồn tại hoặc đã bị BAN");
            }            


            OrderEntity order = new OrderEntity
            {
                BuyerID = command.BuyerID,
                Note = existMethod.Name == "COD" ? command.BuyerID + " thanh toán tiền mặt tại cửa hàng" : command.BuyerID + " thanh toán chuyển khoản tại cửa hàng",
                PaymentMethodID = command.PaymentMethodID,
                Status = existMethod.Name == "COD" ? OrderStatus.COMPLETED : OrderStatus.PENDING,
                TotalCost = 0,
                Type = OrderType.AT_SHOP_ORDER,
                CounterID = staff.CounterID,
                CreatedAt = DateTime.Now,
                CreatorID = _currentUserService.UserId,
                PromotionID = command.PromotionID.IsNullOrEmpty() ? null : existPromotion.ID,
            };

            List<OrderDetailEntity> orderDetails = new List<OrderDetailEntity>();
            //List<ProductEntity> products = new List<ProductEntity>();
            foreach (var item in command.OrderDetails)
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
                
                // lấy giá vàng và giá kc mới nhất
                decimal gCost = 0;
                if (existProduct.GoldID != null)
                {
                    gCost = _goldService.GetGoldPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == existProduct.Gold.Name).BuyCost;
                }
                decimal dCost = 0;
                if (existProduct.DiamondID != null)
                {
                    gCost = _diamondService.GetDiamondPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == existProduct.Diamond.Name).BuyCost;
                }

                orderDetails.Add(new OrderDetailEntity
                {
                    OrderID = order.ID,
                    ProductID = item.ProductID,
                    ProductCost = (existProduct.WageCost + gCost + dCost) * item.Quantity,
                    Quantity = item.Quantity,
                    CreatedAt = DateTime.Now,
                    CreatorID = _currentUserService.UserId
                });
            }

            //COD
            if(existMethod.Name == "COD")
            {
                _orderRepository.Add(order);
                foreach (var orderDetail in orderDetails)
                {
                    _orderDetailRepository.Add(orderDetail);
                    // này là update lại stock product
                    orderDetail.Product.Quantity -= orderDetail.Quantity;
                    orderDetail.Product.LastestUpdateAt = DateTime.Now;
                    _productRepository.Update(orderDetail.Product);
                    // này là + tiền vào order
                    order.TotalCost += orderDetail.ProductCost;              
                }
                if (existPromotion != null)
                {
                    // check xem sử dụng được promotion không
                    if (order.TotalCost < existPromotion.ConditionsOfUse)
                    {
                        return "Không đủ điều kiện sử dụng ưu đãi";
                    }

                    // cập nhật nại status nếu được sử dụng
                    existPromotion.Status = PromotionStatus.USED;
                    existMethod.LastestUpdateAt = DateTime.Now;
                    existMethod.UpdaterID = order.BuyerID;
                    _promotionRepository.Update(existPromotion);

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
                return await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
            }
            // flow này là thanh toán banking
            _orderRepository.Add(order);
            foreach (var orderDetail in orderDetails)
            {
                _orderDetailRepository.Add(orderDetail);               
                // này là + tiền vào order
                order.TotalCost += orderDetail.ProductCost;
            }
            if (existPromotion != null)
            {
                // check xem sử dụng được promotion không
                if (order.TotalCost < existPromotion.ConditionsOfUse)
                {
                    return "Không đủ điều kiện sử dụng ưu đãi";
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
            PaymentInformationModel paymentInformationModel = new PaymentInformationModel
            {
                Amount = (double)order.TotalCost,
                OrderType = order.ID,
                OrderDescription = order.Note,
                Name = order.BuyerID
            };
            await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            //pass httpContext vô service
            var httpContext = _httpContextAccessor.HttpContext;
            var paymentUrl = _vnPayService.CreatePaymentUrl(paymentInformationModel, httpContext);
            return paymentUrl;

        }
    }
}
