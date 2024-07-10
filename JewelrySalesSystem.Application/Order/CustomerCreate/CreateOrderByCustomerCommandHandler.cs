using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
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
        public CreateOrderByCustomerCommandHandler(IOrderRepository orderRepository
            , IOrderDetailRepository orderDetailRepository
            , IProductRepository productRepository
            , IPromotionRepository promotionRepository
            , IUserRepository userRepository
            , ICurrentUserService currentUserService
            , IPaymentMethodRepository paymentMethodRepository
            , IDiamondService diamondService
            , IGoldService goldService)
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
        }
        public async Task<string> Handle(CreateOrderByCustomerCommand command, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.AnyAsync(x => x.ID == command.BuyerID && x.DeleterID == null, cancellationToken);
            if (!existUser)
            {
                throw new NotFoundException("Không tìm thấy người mua với ID: " + command.BuyerID);
            }
            
            var existMethod = await _paymentMethodRepository.AnyAsync(x => x.ID == command.PaymentMethodID && x.DeleterID == null, cancellationToken);
            if (!existMethod)
            {
                throw new NotFoundException("Không tìm thấy phương thức thanh toán với ID: " + command.PaymentMethodID);
            }

            var existPromotion = await _promotionRepository.FindAsync(x => x.ID == command.PromotionID && x.DeleterID == null, cancellationToken);
            if (existPromotion == null && !command.PromotionID.IsNullOrEmpty())
            {
                throw new NotFoundException("Không tìm thấy ưu đãi với ID: " + command.PromotionID);
            }

            OrderEntity order = new OrderEntity 
            {
                BuyerID = command.BuyerID,
                Note = command.BuyerID + "thanh toán online",
                PaymentMethodID = command.PaymentMethodID,
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
                decimal gCost = 0;
                if (existProduct.GoldID != null)
                {
                    gCost =  _goldService.GetGoldPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == existProduct.Gold.Name).BuyCost;
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
                    Quantity = item.Quantity
                });               
            }
            _orderRepository.Add(order);

            foreach (var orderDetail in orderDetails)
            {
                _orderDetailRepository.Add(orderDetail);
                order.TotalCost += orderDetail.ProductCost;
            }
            
            return await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
