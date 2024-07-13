using AutoMapper;
using JewelrySalesSystem.Application.Promotion;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.GetAll
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQuery, List<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly ICounterRepository _counterRepository;

        public GetAllOrderQueryHandler(IOrderRepository orderRepository
            , IMapper mapper
            , ICounterRepository counterRepository
            , IUserRepository userRepository
            , IPaymentMethodRepository paymentMethodRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _counterRepository = counterRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _userRepository = userRepository;
        }

        public async Task<List<OrderDto>> Handle(GetAllOrderQuery request, CancellationToken cancellationToken)
        {
            var repostList = await _orderRepository.FindAllAsync(x => x.DeletedAt == null, cancellationToken);
            if(!repostList.Any()) throw new NotFoundException("Không tìm thấy order nào !!");

            var users = await _userRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.FullName, cancellationToken);
            var counters = await _counterRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);
            var paymentMethods = await _paymentMethodRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);


            return repostList.MapToOrderDtoList(_mapper, counters, users, paymentMethods);
        }
    }
}
