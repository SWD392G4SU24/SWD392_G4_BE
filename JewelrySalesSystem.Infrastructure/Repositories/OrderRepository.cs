using AutoMapper;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<OrderEntity, OrderEntity, ApplicationDbContext>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync(CancellationToken cancellationToken)
        {
            return await _context.Orders.ToListAsync(cancellationToken).ConfigureAwait(false);  
        }

        public async Task<OrderEntity> GetOrderByIdAsnyc(string id, CancellationToken cancellationToken)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.ID == id, cancellationToken).ConfigureAwait(false);
        }
    }
}
