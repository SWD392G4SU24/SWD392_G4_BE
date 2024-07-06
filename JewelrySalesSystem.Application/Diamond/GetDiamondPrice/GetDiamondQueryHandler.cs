using AutoMapper;
using JewelrySalesSystem.Application.Diamon.GetAll;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using MediatR;

namespace JewelrySalesSystem.Application.Diamond
{
    public class GetDiamondQueryHandler : IRequestHandler<GetDiamondQuery, List<DiamondDto>>
    {
        private readonly IDiamondService _diamondService;
        private readonly IMapper _mapper;

        public GetDiamondQueryHandler(IDiamondService diamondService, IMapper mapper)
        {
            _diamondService = diamondService;
            _mapper = mapper;
        }

        public async Task<List<DiamondDto>> Handle(GetDiamondQuery request, CancellationToken cancellationToken)
        {
            var listDiamond = await _diamondService.GetDiamondPricesAsync(cancellationToken);
            return listDiamond.MapToDiamondDtoList(_mapper);
        }
    }
}
