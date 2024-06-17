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
    public class GoldRepository : RepositoryBase<GoldEntity, GoldEntity, ApplicationDbContext>, IGoldRopository
    {
        private readonly ApplicationDbContext _context;
        public GoldRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<GoldEntity>> GetAllGoldAsync(CancellationToken cancellationToken)
        {
            return await _context.Golds.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<GoldEntity> GetGoldByIdAsnyc(int id, CancellationToken cancellationToken)
        {
           return await _context.Golds.FirstOrDefaultAsync(x => x.ID == id, cancellationToken).ConfigureAwait(false);
        }
    }
}
