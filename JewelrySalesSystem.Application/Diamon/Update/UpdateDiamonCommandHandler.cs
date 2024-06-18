using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Diamon.Create;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.Update
{
    public class UpdateDiamonCommandHandler : IRequestHandler<UpdateDiamonCommand, string>
    {
        private readonly IDiamonRepository _diamonRepository;
        private readonly ICurrentUserService _currentUserService;

        public UpdateDiamonCommandHandler(IDiamonRepository diamonRepository, ICurrentUserService currentUserService)
        {
            _diamonRepository = diamonRepository;
            _currentUserService = currentUserService;
        }

        public async Task<string> Handle(UpdateDiamonCommand request, CancellationToken cancellationToken)
        {
            var diamon = await _diamonRepository.GetDiamonByIdAsnyc(request.ID, cancellationToken);
            if (diamon is null) throw new NotFoundException("Diamon is not exist");
            // Update dimon field
            diamon.BuyCost = request.BuyCost;
            diamon.Name = request.Name;
            diamon.SellCost = request.SellCost;
            diamon.UpdaterID = _currentUserService.UserId;
            diamon.LastestUpdateAt = DateTime.UtcNow;
            _diamonRepository.Update(diamon);
            await _diamonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Update Diamon Successfully";
        }
    }
}
