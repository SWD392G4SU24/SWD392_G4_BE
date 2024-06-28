using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Commons.Interfaces
{
    public interface IDiamondService
    {
        Task<List<DiamondEntity>> GetDiamondPricesAsync(CancellationToken cancellationToken = default);
        Task<bool> CheckIfDiamondExistAsync(int? diamondId, CancellationToken cancellationToken);
    }
}
