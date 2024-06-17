using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Repositories
{
    public interface IOrderDetailRepository : IEFRepository<OrderDetailEntity, OrderDetailEntity>
    {
        Task<IEnumerable<OrderDetailEntity>> GetAllOrderDetailsAsync(CancellationToken cancellationToken);
        Task<OrderDetailEntity> GetOrderDetailByIdAsnyc(string id, CancellationToken cancellationToken);
    }
}
