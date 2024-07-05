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
    public class GetByDiamondIDQueryHandler : IRequestHandler<GetDiamondByIDQuery, DiamondDto>
    {
        private readonly IDiamondRepository _diamondRepository;

        public GetByDiamondIDQueryHandler(IDiamondRepository diamondRepository)
        {
            _diamondRepository = diamondRepository;
        }
        public async Task<DiamondDto> Handle(GetDiamondByIDQuery request, CancellationToken cancellationToken)
        {
            var diamon = await _diamondRepository.FindAsync(s => s.ID == request.ID, cancellationToken)
                ?? throw new NotFoundException("Diamond không tồn tại");

            return new DiamondDto 
            {
                Name = diamon.Name,
                BuyCost = diamon.BuyCost, 
                SellCost = diamon.SellCost
            };
        }
    }
}
