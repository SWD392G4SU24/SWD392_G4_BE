using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Commons.Interfaces
{
    public interface IGoldService
    {
        Task<List<GoldEntity>> GetGoldPricesAsync(CancellationToken cancellationToken = default);
        Task<bool> CheckIfGoldExistAsync(int? GoldId, CancellationToken cancellationToken);
    }
}
