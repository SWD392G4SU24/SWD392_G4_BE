using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Repositories
{
    public interface IProductRepository : IEFRepository<ProductEntity, ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> GetAllProductsAsync(CancellationToken cancellationToken);
        Task<ProductEntity> GetProductByIdAsnyc(string id, CancellationToken cancellationToken);
    }
}
