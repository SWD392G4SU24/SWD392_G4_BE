using AutoMapper;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Infrastructure.ExternalService.GoldBtmc;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.GoldBtmc.GetGoldPrice
{
    public class GetGoldPriceQueryHandler : IRequestHandler<GetGoldPriceQuery, List<GoldDto>>
    {
        private readonly IGoldService _goldService;
        private readonly IMapper _mapper;
        public GetGoldPriceQueryHandler(IGoldService goldService, IMapper mapper)
        {
            _mapper = mapper;
            _goldService = goldService;
        }
        public async Task<List<GoldDto>> Handle(GetGoldPriceQuery query, CancellationToken cancellationToken)
        {
            var listGold = await _goldService.GetGoldPricesAsync(cancellationToken);
            return listGold.MapToGoldBtmcDtoList(_mapper);  
        }
    }
}
