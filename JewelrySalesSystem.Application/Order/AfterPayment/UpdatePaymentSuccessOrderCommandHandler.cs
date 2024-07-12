using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.AfterPayment
{
    public class UpdatePaymentSuccessOrderCommandHandler : IRequestHandler<UpdatePaymentSuccessOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IProductRepository _productRepository;
        public UpdatePaymentSuccessOrderCommandHandler(IOrderRepository orderRepository
            , IOrderDetailRepository orderDetailRepository
            , ICurrentUserService currentUserService
            , IPromotionRepository promotionRepository
            , IProductRepository productRepository)
        {
            _currentUserService = currentUserService;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _productRepository = productRepository;
            _promotionRepository = promotionRepository;
        }

        public async Task<string> Handle(UpdatePaymentSuccessOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindAsync(x => x.ID == command.ID && x.DeletedAt == null, cancellationToken);
            if (order == null)
            {
                throw new NotFoundException("Order không tồn tại");
            }
            if (!order.Status.Equals(OrderStatus.PENDING))
            {
                return "Order đang không trạng thái xử lý";
            }
            var existPromotion = await _promotionRepository.FindAsync(x => x.ID.Equals(order.PromotionID) && x.DeletedAt == null, cancellationToken);
            if (existPromotion?.Status == PromotionStatus.UNAVAILABLE)
            {
                order.Status = OrderStatus.REFUNDED;
                _orderRepository.Update(order);
                await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                return "REFUNDED, Ưu đã hết hạn sử dụng";
            }
            
            var orderDetails = order.OrderDetails.Where(x => x.DeletedAt == null);
            foreach(var orderDetail in orderDetails)
            {
                var existProduct = await _productRepository.FindAsync(x => x.ID == orderDetail.ProductID && x.DeletedAt == null, cancellationToken);
                if (existProduct == null)
                {
                    throw new NotFoundException("Product " + orderDetail.ProductID + " không tồn tại");
                }

                if (existProduct.Quantity < orderDetail.Quantity)
                {
                    order.Status = OrderStatus.REFUNDED;
                    _orderRepository.Update(order);
                    await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
                    // call API refund cua VnPay, nhma sandbox không xài dc :vv
                    return "REFUNDED, not enought Product's stock!!! \nProductID: " + orderDetail.ProductID;
                }

                existProduct.Quantity -= orderDetail.Quantity;
                existProduct.LastestUpdateAt = DateTime.Now;
                existProduct.UpdaterID = _currentUserService.UserId;
                _productRepository.Update(existProduct);

                orderDetail.LastestUpdateAt = DateTime.Now;
                orderDetail.UpdaterID = _currentUserService.UserId;
                _orderDetailRepository.Update(orderDetail);
            }

            if(existPromotion != null)
            {
                existPromotion.Status = PromotionStatus.USED;
                existPromotion.UpdaterID = _currentUserService.UserId;
                existPromotion.LastestUpdateAt = DateTime.UtcNow;
                _promotionRepository.Update(existPromotion);
            }
            
            order.Status = OrderStatus.PAID;
            order.PickupDate = DateTime.Now.AddDays(2);
            order.LastestUpdateAt = DateTime.UtcNow;
            order.UpdaterID = _currentUserService.UserId;
            _orderRepository.Update(order);
            return await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
