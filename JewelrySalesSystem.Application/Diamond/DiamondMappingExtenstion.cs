using AutoMapper;
using JewelrySalesSystem.Application.Diamon;
using JewelrySalesSystem.Domain.Entities.Configured;


namespace JewelrySalesSystem.Application.Diamond
{
    public static class DiamondMappingExtenstion
    {
        public static DiamondDto MapToDiamondDto(this DiamondEntity projectFrom, IMapper mapper)
        => mapper.Map<DiamondDto>(projectFrom);
        public static List<DiamondDto> MapToDiamondDtoList(this IEnumerable<DiamondEntity> projectFrom, IMapper mapper)
         => projectFrom.Select(x => x.MapToDiamondDto(mapper)).ToList();
    }
}
