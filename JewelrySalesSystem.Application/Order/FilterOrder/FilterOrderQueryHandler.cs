using AutoMapper;
using JewelrySalesSystem.Application.Common.Pagination;
using JewelrySalesSystem.Application.Users;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.FilterOrder
{
    public class FilterOrderQueryHandler : IRequestHandler<FilterOrderQuery, PagedResult<OrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        private readonly ICounterRepository _counterRepository;
        private readonly IProductRepository _productRepository;
        public FilterOrderQueryHandler(IOrderRepository orderRepository
            , IMapper mapper
            , ICounterRepository counterRepository
            , IUserRepository userRepository
            , IPaymentMethodRepository paymentMethodRepository
            , IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _counterRepository = counterRepository;
            _paymentMethodRepository = paymentMethodRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }
        public async Task<PagedResult<OrderDto>> Handle(FilterOrderQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<OrderEntity>, IQueryable<OrderEntity>> queryOptions = query =>
            {
                query = query.Where(x => x.DeletedAt == null);
                if (!string.IsNullOrEmpty(request.BuyerID))
                {
                    query = query.Where(x => x.BuyerID.Contains(request.BuyerID));
                }
                if (request.CounterID != 0)
                {
                    query = query.Where(x => x.CounterID == request.CounterID);
                }
                if (request.PaymentMethodID != 0)
                {
                    query = query.Where(x => x.PaymentMethodID == request.PaymentMethodID);
                }
                if (!string.IsNullOrEmpty(request.Type.ToString()))
                {
                    query = query.Where(x => x.Type.Equals(request.Type));
                }
                if (!string.IsNullOrEmpty(request.Status.ToString()))
                {
                    query = query.Where(x => x.Status.Equals(request.Status));
                }
                return query;
            };
            var result = await _orderRepository.FindAllAsync(request.PageNumber, request.PageSize, queryOptions, cancellationToken);
            
            var users = await _userRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.FullName, cancellationToken);
            var counters = await _counterRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);
            var paymentMethods = await _paymentMethodRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);
            var productNames = await _productRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.Name, cancellationToken);
            var productImgUrl = await _productRepository.FindAllToDictionaryAsync(x => x.DeletedAt == null, x => x.ID, x => x.ImageURL, cancellationToken);

            return PagedResult<OrderDto>.Create(
                totalCount: result.TotalCount,
                pageCount: result.PageCount,
                pageSize: result.PageSize,
                pageNumber: result.PageNo,
                data: result.MapToOrderDtoList(_mapper, counters, users, paymentMethods, productNames, productImgUrl));
        }
    }
}
