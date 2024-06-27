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
    public class GetByIDQueryHandler : IRequestHandler<GetByIDQuery, DiamonDto>
    {
        private readonly IDiamonRepository _diamonRepository;

        public GetByIDQueryHandler(IDiamonRepository diamonRepository)
        {
            _diamonRepository = diamonRepository;
        }
        public async Task<DiamonDto> Handle(GetByIDQuery request, CancellationToken cancellationToken)
        {
            var diamon = await _diamonRepository.FindAsync(s => s.ID == request.ID, cancellationToken);
            if (diamon is null) throw new NotFoundException("Diamon is not exist");
            return new DiamonDto 
            {
                Name = diamon.Name,
                BuyCost = diamon.BuyCost, 
                Id = diamon.ID,
                SellCost = diamon.SellCost
            };
        }
    }
}
