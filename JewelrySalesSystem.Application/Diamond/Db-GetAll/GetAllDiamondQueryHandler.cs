using AutoMapper;
using JewelrySalesSystem.Application.Diamon.GetAll;
using JewelrySalesSystem.Application.Diamon;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;

namespace JewelrySalesSystem.Application.Diamond.Db_GetAll
{
    public class GetAllDiamondQueryHandler : IRequestHandler<GetAllDiamondQuery, List<DiamondDto>>
    {
        private readonly IDiamondRepository _diamondRepository;
        private readonly IMapper _mapper;

        public GetAllDiamondQueryHandler(IDiamondRepository diamondRepository, IMapper mapper)
        {
            _diamondRepository = diamondRepository;
            _mapper = mapper;
        }

        public async Task<List<DiamondDto>> Handle(GetAllDiamondQuery request, CancellationToken cancellationToken)
        {
             var listDiamond = await _diamondRepository
                            .FindAllAsync(cancellationToken);
    
            var mostRecentDiamonds = listDiamond.GroupBy(x => x.Name)
                            .Select(g => g.OrderByDescending(d => d.CreatedAt).First())
                            .ToList();

            return mostRecentDiamonds.MapToDiamondDtoList(_mapper);
        }
    }
}
