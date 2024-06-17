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
    public class OrderDetailRepository : RepositoryBase<OrderDetailEntity, OrderDetailEntity, ApplicationDbContext>, IOrderDetailRepository

    {
        private readonly ApplicationDbContext _context;
        public OrderDetailRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<OrderDetailEntity>> GetAllOrderDetailsAsync(CancellationToken cancellationToken)
        {
            return await _context.OrderDetails.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<OrderDetailEntity> GetOrderDetailByIdAsnyc(string id, CancellationToken cancellationToken)
        {
            return await _context.OrderDetails.FirstOrDefaultAsync(x => x.ID == id, cancellationToken).ConfigureAwait(false);
        }
    }
}
