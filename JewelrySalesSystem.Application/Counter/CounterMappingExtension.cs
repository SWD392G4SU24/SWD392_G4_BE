using AutoMapper;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using JewelrySalesSystem.Application.Role;
using JewelrySalesSystem.Domain.Entities.Configured;

namespace JewelrySalesSystem.Application.Counter
{
    public static class CounterMappingExtension
    {
        public static CounterDto MapToCounterDto(this CounterEntity projectForm, IMapper mapper)
            => mapper.Map<CounterDto>(projectForm);
        public static List<CounterDto> MapToCounterDtoList(this IEnumerable<CounterEntity> projectForm, IMapper mapper)
            => projectForm.Select(x => x.MapToCounterDto(mapper)).ToList();
    }
}
