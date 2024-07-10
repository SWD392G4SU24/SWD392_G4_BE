using AutoMapper;
using JewelrySalesSystem.Application.Common.Mappings;
using JewelrySalesSystem.Domain.Entities.Configured;

namespace JewelrySalesSystem.Application.Counter.CreateCounter
{
    public class CounterDto : IMapFrom<CounterEntity>
    {
        public CounterDto() { }
        public int ID { get; set; }
        public string Name { get; set; }
        public int CategoryID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CounterEntity, CounterDto>();
        }
    }
}
