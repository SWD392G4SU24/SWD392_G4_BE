using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.GetAll
{
    public class GetDiamonQueryHandler : IRequestHandler<GetDiamonQuery, IEnumerable<DiamonDto>>
    {
        private readonly IDiamonRepository _diamonRepository;

        public GetDiamonQueryHandler(IDiamonRepository diamonRepository)
        {
            _diamonRepository = diamonRepository;
        }

        public async Task<IEnumerable<DiamonDto>> Handle(GetDiamonQuery request, CancellationToken cancellationToken)
        {
            var diamon = await _diamonRepository.FindAllAsync(cancellationToken);
            return diamon.Select(s => new DiamonDto
            {
                Name = s.Name,
                BuyCost = s.BuyCost,
                Id = s.ID,
                SellCost = s.SellCost,
            }).ToList();
        }
    }
}
