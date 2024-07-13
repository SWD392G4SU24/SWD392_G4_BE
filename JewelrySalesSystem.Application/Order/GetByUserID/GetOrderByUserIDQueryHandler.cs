using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Order.GetByUserID
{
    public class GetOrderByUserIDQueryHandler : IRequestHandler<GetOrderByUserIDQuery, PagedResult<OrderDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly ICounterRepository _counterRepository;
        public GetOrderByUserIDQueryHandler(IOrderRepository orderRepository
            , IUserRepository userRepository
            , IMapper mapper
            , ICounterRepository counterRepository
            , IPaymentMethodRepository paymentMethodRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _counterRepository = counterRepository;
            _paymentMethodRepository = paymentMethodRepository;
        }
        public async Task<PagedResult<OrderDto>> Handle(GetOrderByUserIDQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsync(x => x.ID == request.UserID && x.DeletedAt == null, cancellationToken);
            if(user == null)
            {
                throw new NotFoundException("Không tìm thấy user với ID: " + request.UserID);
            }
            if(user.Status == UserStatus.BANNED)
            {
                throw new Exception("Tài khoản đã bị BAN, liên hệ admin để mở khóa !!!");
            }
            
            var result = await _orderRepository.FindAllAsync(x => x.BuyerID == user.ID && x.Status != OrderStatus.PENDING && x.DeletedAt == null, request.PageNumber, request.PageSize, cancellationToken);

            Dictionary<string, string> userDictionary = new Dictionary<string, string>
            {
                { user.ID, user.FullName }
            };
            var counters = await _counterRepository.FindAllToDictionaryAsync(x => x.DeletedAt != null, x => x.ID, x => x.Name, cancellationToken);
            var paymentMethods = await _paymentMethodRepository.FindAllToDictionaryAsync(x => x.DeletedAt != null, x => x.ID, x => x.Name, cancellationToken);


            return PagedResult<OrderDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToOrderDtoList(_mapper, counters, userDictionary, paymentMethods)
                );
        }
    }
}
