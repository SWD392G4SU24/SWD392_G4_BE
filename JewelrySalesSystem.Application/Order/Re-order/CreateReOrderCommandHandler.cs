using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Functions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.Re_order
{
    public class CreateReOrderCommandHandler : IRequestHandler<CreateReOrderCommand, string>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IUserRepository _userRepository;
        private readonly IGoldService _goldService;
        private readonly IDiamondService _diamondService;
        private readonly ICalculator _tools;
        private readonly ICurrentUserService _currentUserService;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        public CreateReOrderCommandHandler(IDiamondService diamondService
            , IOrderDetailRepository orderDetailRepository
            , IOrderRepository orderRepository
            , IUserRepository userRepository
            , IGoldService goldService
            , ICalculator tools
            , ICurrentUserService currentUserService
            , IPaymentMethodRepository paymentMethodRepository)
        {
            _orderDetailRepository = orderDetailRepository;
            _userRepository = userRepository;
            _goldService = goldService;
            _orderRepository = orderRepository;
            _diamondService = diamondService;
            _tools = tools;
            _paymentMethodRepository = paymentMethodRepository;
            _currentUserService = currentUserService;
        }
        public async Task<string> Handle(CreateReOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _userRepository.FindAsync(x => x.ID == request.CustomerID && x.DeletedAt == null, cancellationToken);
            if (customer == null)
            {
                throw new NotFoundException("Không tìm thấy User");
            }
            if(customer.Status.Equals(UserStatus.BANNED))
            {
                return "Người dùng đã bị BAN. Liên hệ admin để mở khóa tài khoản";
            }
            if (customer.Status.Equals(UserStatus.UNVERIFIED))
            {
                return "Tài khoản chưa được xác thực";
            }
            var paymentMethod = await _paymentMethodRepository.FindAsync(x => x.Name.Equals("COD") && x.DeleterID == null, cancellationToken);
            if (paymentMethod == null)
            {
                throw new NotFoundException("Phương thức thanh toán bị lỗi");
            }
            var staff = await _userRepository.FindAsync(x => x.ID == _currentUserService.UserId && x.DeletedAt == null, cancellationToken);
            if (staff == null)
            {
                throw new NotFoundException("Account staff không tồn tại hoặc đã bị xóa");
            }
            OrderEntity order = new OrderEntity
            {
                TotalCost = 0,
                PaymentMethodID = paymentMethod.ID,
                Note = "JeWellry mua lại sản phẩm",
                Type = OrderType.RE_ORDER,
                Status = OrderStatus.COMPLETED,
                PickupDate = DateTime.UtcNow,
                BuyerID = staff.ID,
                CreatorID = _currentUserService.UserId
            };
            _orderRepository.Add(order);

            if (!string.IsNullOrEmpty(request.OrderDetailID))
            {
                var receipt = await _orderDetailRepository.FindAsync(x => x.ID.Equals(request.OrderDetailID) && x.DeletedAt == null, cancellationToken);
                if (receipt == null)
                {
                    throw new NotFoundException("Không tìm thấy hóa đơn với ID: " +  request.OrderDetailID);
                }
                if (!receipt.Order.PickupDate.HasValue)
                {
                    return "Sản phẩm chưa được nhận";
                }
                if ( (receipt.Order.Status == OrderStatus.COMPLETED || receipt.Order.Status == OrderStatus.PAID) && 
                    DateTime.UtcNow > receipt.Order.PickupDate.Value.AddYears(2))
                {
                    return "Hóa đơn " + request.OrderDetailID + " đã quá 2 năm kể từ ngày nhận sản phẩm";
                }

                var diamond = receipt.Product.Diamond;
                var gold = receipt.Product.Gold;
                decimal dscost = 0;
                decimal gbCost = 0;
                if (diamond != null && (diamond.Name.Contains("7ly") || diamond.Name.Contains("8ly") || diamond.Name.Contains("9ly")))
                {
                    dscost = diamond.SellCost;
                }
                if (gold != null)
                {
                    var gService = await _goldService.GetGoldPricesAsync(cancellationToken);
                    var goldPrice = gService.FirstOrDefault(v => v.Name == gold.Name);
                    gbCost = goldPrice?.BuyCost ?? 0;
                }
                decimal reOrderCost = _tools.CalculateReorderCost(dscost, gbCost, receipt.Product?.GoldWeight ?? 0f);

                OrderDetailEntity orderDetail = new OrderDetailEntity
                {
                    OrderID = order.ID,
                    ProductCost = (decimal)(reOrderCost * request?.Quantity ?? 1),
                    ProductID = receipt.ProductID,
                    Quantity = request?.Quantity ?? 1,
                    GoldBuyCost = gbCost,
                    DiamondSellCost = dscost,
                    CreatorID = _currentUserService.UserId,
                };
                order.TotalCost += orderDetail.ProductCost;
                _orderDetailRepository.Add(orderDetail);
                order.OrderDetails.Add(orderDetail);
                return await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
            }

            if(!request.GoldWeight.HasValue)
            {
                return "GoldWeight";
            }
            var gservice = await _goldService.GetGoldPricesAsync(cancellationToken);
            var goldprice = gservice.FirstOrDefault(v => v.Name == request.GoldType);
            if (goldprice == null)
            {
                throw new NotFoundException("Không tìm thấy GoldType: " + request.GoldType);
            }
            decimal gbcost = goldprice.BuyCost;           
            decimal reOrderGoldCost = _tools.CalculateReorderCost(0, gbcost, (float)request.GoldWeight);
            order.TotalCost += reOrderGoldCost;
            return await _orderRepository.UnitOfWork.SaveChangesAsync(cancellationToken) > 0 ? "Tạo thành công" : "Tạo thất bại";
        }
    }
}
