using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Repositories.ConfiguredEntity
{
    public interface IGoldRopository : IEFRepository<GoldEntity, GoldEntity>
    {
        Task<IEnumerable<GoldEntity>> GetAllGoldAsync(CancellationToken cancellationToken);
        Task<GoldEntity> GetGoldByIdAsnyc(int id, CancellationToken cancellationToken);
    }
}
