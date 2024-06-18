using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.Create
{
    public class CreateDiamonCommandHandler : IRequestHandler<CreateDiamonCommand, string>
    {
        private readonly IDiamonRepository _diamonRepository;
        private readonly ICurrentUserService _currentUserService;

        public CreateDiamonCommandHandler(IDiamonRepository diamonRepository, ICurrentUserService currentUserService)
        {
            _diamonRepository = diamonRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(CreateDiamonCommand request, CancellationToken cancellationToken)
        {
            var diamon = new DiamonEntity
            {
                BuyCost = request.BuyCost,
                Name = request.Name,
                SellCost = request.SellCost,
                CreatedAt = DateTime.UtcNow,
                CreatorID = _currentUserService.UserId,
            };
            _diamonRepository.Add(diamon);
            await _diamonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Created Diamon Successfully with ID: " + diamon.ID;
        }
    }
}
