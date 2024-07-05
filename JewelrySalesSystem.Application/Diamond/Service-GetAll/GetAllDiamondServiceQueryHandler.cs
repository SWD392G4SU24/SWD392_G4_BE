using AutoMapper;
using JewelrySalesSystem.Application.Diamond;
using JewelrySalesSystem.Application.GoldBtmc;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.ExternalService.Diamond;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.GetAll
{
    public class GetAllDiamondServiceQueryHandler : IRequestHandler<GetAllDiamondServiceQuery, List<DiamondServiceDto>>
    {
        private readonly IDiamondService _diamondService;
        private readonly IMapper _mapper;

        public GetAllDiamondServiceQueryHandler(IDiamondService diamondService, IMapper mapper)
        {
            _diamondService = diamondService;
            _mapper = mapper;
        }

        public async Task<List<DiamondServiceDto>> Handle(GetAllDiamondServiceQuery request, CancellationToken cancellationToken)
        {
            var listDiamond = await _diamondService.GetDiamondPricesAsync(cancellationToken);
            return listDiamond.MapToDiamondServiceDtoList(_mapper);
        }
    }
}
