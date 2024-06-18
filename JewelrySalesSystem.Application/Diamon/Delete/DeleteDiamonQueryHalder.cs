using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.Delete
{
    public class DeleteDiamonQueryHalder : IRequestHandler<DeleteDiamonQuery, string>
    {
        private readonly IDiamonRepository _diamonRepository;   
        private readonly ICurrentUserService _userService;

        public DeleteDiamonQueryHalder(IDiamonRepository diamonRepository, ICurrentUserService userService)
        {
            _diamonRepository = diamonRepository;
            _userService = userService;
        }

        public async Task<string> Handle(DeleteDiamonQuery request, CancellationToken cancellationToken)
        {
            var diamon = await _diamonRepository.GetDiamonByIdAsnyc(request.ID, cancellationToken);
            if (diamon is null) throw new NotFoundException("Diamon is not exist");
            diamon.DeletedAt = DateTime.UtcNow;
            diamon.DeleterID = _userService.UserId;
            _diamonRepository.Update(diamon);
            await _diamonRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return "Delete Diamon Successfully" ;
        }
    }
}
