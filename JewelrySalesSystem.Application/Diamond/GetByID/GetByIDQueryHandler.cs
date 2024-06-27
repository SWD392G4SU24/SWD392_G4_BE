using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.GetByID
{
    public class GetByIDQueryHandler : IRequestHandler<GetByIDQuery, DiamondDto>
    {
        private readonly IDiamondRepository _diamonRepository;

        public GetByIDQueryHandler(IDiamondRepository diamonRepository)
        {
            _diamonRepository = diamonRepository;
        }
        public async Task<DiamondDto> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            var diamon = await _diamonRepository.FindAsync(s => s.ID == request.ID, cancellationToken);
            if (diamon is null) throw new NotFoundException("Diamon is not exist");
            return new DiamondDto 
            {
                Name = diamon.Name,
                BuyCost = diamon.BuyCost, 
                Id = diamon.ID,
                SellCost = diamon.SellCost
            };
        }
    }
}
