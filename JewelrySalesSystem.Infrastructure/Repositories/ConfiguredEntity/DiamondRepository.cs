using AutoMapper;
using JewelrySalesSystem.Domain.Entities.Configured;
using JewelrySalesSystem.Domain.Repositories.ConfiguredEntity;
using JewelrySalesSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Repositories.ConfiguredEntity
{
    public class DiamondRepository : RepositoryBase<DiamondEntity, DiamondEntity, ApplicationDbContext>, IDiamondRepository
    {
        private readonly ApplicationDbContext _context;
        public DiamondRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
        }

       
    }
}
