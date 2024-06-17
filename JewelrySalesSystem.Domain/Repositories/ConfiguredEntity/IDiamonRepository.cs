using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Repositories.ConfiguredEntity
{
    public interface IDiamonRepository : IEFRepository<DiamonEntity, DiamonEntity>
    {
        Task<IEnumerable<DiamonEntity>> GetAllDiamonAsync(CancellationToken cancellationToken);
        Task<DiamonEntity> GetDiamonByIdAsnyc(int id, CancellationToken cancellationToken);
    }
}
