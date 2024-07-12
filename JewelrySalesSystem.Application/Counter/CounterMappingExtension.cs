using AutoMapper;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Application.Users;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using Org.BouncyCastle.Utilities;
using System.Data;

namespace JewelrySalesSystem.Application.Counter
{
    public static class CounterMappingExtension
    {
        public static CounterDto MapToCounterDto(this CounterEntity projectForm, IMapper mapper)
            => mapper.Map<CounterDto>(projectForm);
        public static List<CounterDto> MapToCounterDtoList(this IEnumerable<CounterEntity> projectForm, IMapper mapper)
            => projectForm.Select(x => x.MapToCounterDto(mapper)).ToList();


        public static CounterRevenueDto MapToCounterRevenueDto(this CounterEntity projectForm, IMapper mapper)
            => mapper.Map<CounterRevenueDto>(projectForm);
        public static CounterRevenueDto MapToCounterRevenueDto(this CounterEntity projectForm, IMapper mapper, decimal totalPrice, int ordersNumber)
        {
            var dto = mapper.Map<CounterRevenueDto>(projectForm);
            dto.TotalPrice = totalPrice;
            dto.OrdersNumber = ordersNumber;
            return dto;
        }
        public static List<CounterRevenueDto> MapToCounterRevenueDtoList(this IEnumerable<CounterEntity> entities, IMapper mapper, Dictionary<int, decimal> totalPrice, Dictionary<int, int> ordersNumber)
           => entities.Select(x =>
           x.MapToCounterRevenueDto(mapper,
               totalPrice.ContainsKey(x.ID) ? totalPrice[x.ID] : 0,
               ordersNumber.ContainsKey(x.ID) ? ordersNumber[x.ID] : 0
           )).ToList();
    }
}
