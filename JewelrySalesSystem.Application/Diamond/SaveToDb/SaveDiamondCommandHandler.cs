using JewelrySalesSystem.Domain.Commons.Exceptions;
using JewelrySalesSystem.Domain.Commons.Interfaces;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamond.SaveToDb
{
    public class SaveDiamondCommandHandler : IRequestHandler<SaveDiamondCommand, string>
    {
        private readonly IDiamondRepository _diamondRepository;
        private readonly IDiamondService    _diamondService;

        public SaveDiamondCommandHandler(IDiamondRepository diamondRepository, IDiamondService diamondService)
        {
            _diamondRepository = diamondRepository;
            _diamondService = diamondService;
        }

        public async Task<string> Handle(SaveDiamondCommand request, CancellationToken cancellationToken)
        {
            var listdiamond = await _diamondService.GetDiamondPricesAsync(cancellationToken);
            
            foreach (var item in listdiamond)
            {
                var existDiamond = await _diamondRepository.AnyAsync(x => x.CreatedAt == item.CreatedAt, cancellationToken);
                if (existDiamond)
                {
                    throw new DuplicationException("Diamond đã tồn tại");
                }
                _diamondRepository.Add(new DiamondEntity
                {
                    BuyCost = item.BuyCost,
                    Name = item.Name,
                    SellCost = item.SellCost,
                    CreatedAt = item.CreatedAt
                });
            }
            var result = await _diamondRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return result == 0 ? "Lưu diamond thất bại" : "Lưu diamond thành công";

        }
    }
}
