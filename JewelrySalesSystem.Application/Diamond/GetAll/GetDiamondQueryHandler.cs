using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.GetAll
{
    public class GetDiamondQueryHandler : IRequestHandler<GetDiamondQuery, IEnumerable<DiamondDto>>
    {
        private readonly IDiamondRepository _diamonRepository;

        public GetDiamondQueryHandler(IDiamondRepository diamonRepository)
        {
            _diamonRepository = diamonRepository;
        }

        public async Task<IEnumerable<DiamondDto>> Handle(GetDiamondQuery request, CancellationToken cancellationToken)
        {
            var diamon = await _diamonRepository.FindAllAsync(cancellationToken);
            return diamon.Select(s => new DiamondDto
            {
                Name = s.Name,
                BuyCost = s.BuyCost,
                Id = s.ID,
                SellCost = s.SellCost,
            }).ToList();
        }
    }
}
