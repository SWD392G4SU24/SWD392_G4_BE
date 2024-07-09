using JewelrySalesSystem.Domain.Entities.Configured;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Repositories.ConfiguredEntity
{
    public interface IRoleRepository : IEFRepository<RoleEntity, RoleEntity>
    {
        Task<RoleEntity> GetByNameAsync(string roleName);
    }
}
