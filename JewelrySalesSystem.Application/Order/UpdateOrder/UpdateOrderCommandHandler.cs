using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Common.Models;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Functions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPromotionRepository _promotionRepository;
        private readonly IProductRepository _productRepository;
        private readonly IGoldService _goldService;
        private readonly IDiamondService _diamondService;
        private readonly ICalculator _tools;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository
            , IOrderDetailRepository orderDetailRepository
            , ICurrentUserService currentUserService
            , IPromotionRepository promotionRepository
            , IProductRepository productRepository
            , IDiamondService diamondService
            , IGoldService goldService
            , ICalculator tools)
        {
            _currentUserService = currentUserService;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _promotionRepository = promotionRepository;
            _productRepository = productRepository;
            _diamondService = diamondService;
            _goldService = goldService;
            _tools = tools;
        }
        public async Task<string> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.FindAsync(x => x.ID == command.ID && x.DeletedAt == null, cancellationToken);
            if (order == null)
            {
                throw new NotFoundException("Không tồn tại Order với ID: " + command.ID);
            }

            var existPromotion = await _promotionRepository.FindAsync(x => x.ID == command.PromotionID && x.DeleterID == null, cancellationToken);
            if (existPromotion == null && !command.PromotionID.IsNullOrEmpty())
            {
                throw new NotFoundException("Không tìm thấy ưu đãi với ID: " + command.PromotionID);
            }

            // Map ra Dictionary để check OrderDetail - Product
            var existingOrderDetails = order.OrderDetails.ToDictionary(od => od.ProductID);
            var updatedOrderDetails = command.OrderDetails.ToDictionary(od => od.ProductID);

            // này là xóa OrderDetail nếu như không customer xóa Product khỏi Order
            foreach (var orderDetail in existingOrderDetails)
            {
                if (!updatedOrderDetails.ContainsKey(orderDetail.Key))
                {
                    orderDetail.Value.DeletedAt = DateTime.Now;
                    orderDetail.Value.DeleterID = _currentUserService.UserId;
                }
            }

            
            foreach (var updatedOrderDetail in updatedOrderDetails)
            {
                // Tạo mới OrderDetail
                if (!existingOrderDetails.ContainsKey(updatedOrderDetail.Key))
                {                   
                    var existProduct = await _productRepository.FindAsync(x => x.ID == updatedOrderDetail.Value.ProductID);
                    if (existProduct == null)
                    {
                        throw new NotFoundException("Không tìm thấy sản phẩm với ID: " + updatedOrderDetail.Value.ProductID);
                    }

                    decimal gbCost = 0;
                    decimal gsCost = 0;
                    if (existProduct.GoldID != null)
                    {
                        gbCost = _goldService.GetGoldPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == existProduct.Gold.Name).BuyCost;
                        gsCost = _goldService.GetGoldPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == existProduct.Gold.Name).SellCost;
                    }
                    decimal dsCost = 0;
                    if (existProduct.DiamondID != null)
                    {
                        dsCost = _diamondService.GetDiamondPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == existProduct.Diamond.Name).SellCost;
                    }

                    OrderDetailEntity newOrderDetail = new OrderDetailEntity
                    {
                        OrderID = order.ID,
                        ProductID = updatedOrderDetail.Key,
                        ProductCost = _tools.CalculateSellCost(existProduct.GoldWeight, (gsCost == 0 ? gbCost : gsCost), dsCost, existProduct.WageCost) * updatedOrderDetail.Value.Quantity
                        /*(existProduct.WageCost + (gsCost == 0 ? gbCost : gsCost) + dsCost) * updatedOrderDetail.Value.Quantity*/,
                        GoldBuyCost = existProduct.GoldID != null ? gbCost : null,
                        GoldSellCost = existProduct.GoldID != null ? gsCost : null,
                        DiamondSellCost = existProduct.DiamondID != null ? dsCost : null,
                        Quantity = updatedOrderDetail.Value.Quantity,
                        CreatedAt = DateTime.Now,
                        CreatorID = _currentUserService.UserId,
                    };

                    order.OrderDetails.Add(newOrderDetail);
                    _orderDetailRepository.Add(newOrderDetail);
                }
                //update order detail có sẵn
                else
                {
                    var orderDetail = existingOrderDetails[updatedOrderDetail.Key];
                    orderDetail.Quantity = updatedOrderDetail.Value.Quantity;

                    decimal gbCost = 0;
                    decimal gsCost = 0;
                    if (orderDetail.Product.GoldID != null)
                    {
                        gbCost = _goldService.GetGoldPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == orderDetail.Product.Gold.Name).BuyCost;
                        gsCost = _goldService.GetGoldPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == orderDetail.Product.Gold.Name).SellCost;
                    }
                    decimal dsCost = 0;
                    if (orderDetail.Product.DiamondID != null)
                    {
                        dsCost = _diamondService.GetDiamondPricesAsync(cancellationToken).Result.FirstOrDefault(v => v.Name == orderDetail.Product.Diamond.Name).SellCost;
                    }

                    orderDetail.ProductCost = (orderDetail.Product.WageCost + (gsCost == 0 ? gbCost : gsCost) + dsCost) * updatedOrderDetail.Value.Quantity;
                    orderDetail.GoldBuyCost = orderDetail.Product.GoldID != null ? gbCost : null;
                    orderDetail.GoldSellCost = orderDetail.Product.GoldID != null ? gsCost : null;
                    orderDetail.DiamondSellCost = orderDetail.Product.DiamondID != null ? dsCost : null;
                    orderDetail.UpdaterID = _currentUserService.UserId;
                    orderDetail.LastestUpdateAt = DateTime.Now;
                    _orderDetailRepository.Update(orderDetail);
                }              
            }

            // update lại total cost cho order
            order.TotalCost = 0;
            foreach(var item in order.OrderDetails)
            {
                if(item.DeletedAt == null)
                    order.TotalCost += item.ProductCost;
            }

            // check xem sử dụng được promotion không
            if (existPromotion != null)
            {               
                if (order.TotalCost < existPromotion.ConditionsOfUse)
                {
                    return "Không đủ điều kiện sử dụng ưu đãi";
                }
                if (existPromotion.ExpiresTime < DateTime.Now)
                {
                    return "Ưu đãi đã hết hạn sử dụng";
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

            order.UpdaterID = _currentUserService.UserId;
            order.LastestUpdateAt = DateTime.Now;
            _orderRepository.Update(order);
            return await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Cập nhật thành công" : "Cập nhật thất bại";
        }
    }
}
