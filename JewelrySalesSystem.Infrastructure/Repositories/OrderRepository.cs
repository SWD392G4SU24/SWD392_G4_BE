using AutoMapper;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Persistence;

namespace JewelrySalesSystem.Infrastructure.Repositories
{
    public class OrderRepository : RepositoryBase<OrderEntity, OrderEntity, ApplicationDbContext>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }       
    }
}
