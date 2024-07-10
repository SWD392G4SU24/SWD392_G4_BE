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
 
        public OrderDetailRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        
        }

    }
}
