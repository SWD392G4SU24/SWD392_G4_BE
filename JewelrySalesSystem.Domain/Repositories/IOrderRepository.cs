using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Repositories
{
    public interface IOrderRepository : IEFRepository<OrderEntity, OrderEntity>
    {
        Task<IEnumerable<OrderEntity>> GetAllOrdersAsync(CancellationToken cancellationToken);
        Task<OrderEntity> GetOrderByIdAsnyc(string id, CancellationToken cancellationToken);
    }
}
