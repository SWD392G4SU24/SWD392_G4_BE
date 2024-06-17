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
    public class DiamonRepository : RepositoryBase<DiamonEntity, DiamonEntity, ApplicationDbContext>, IDiamonRepository
    {
        private readonly ApplicationDbContext _context;
        public DiamonRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<DiamonEntity>> GetAllDiamonAsync(CancellationToken cancellationToken)
        {
            return await _context.Diamons.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<DiamonEntity> GetDiamonByIdAsnyc(int id, CancellationToken cancellationToken)
        {
            return await _context.Diamons.FirstOrDefaultAsync(x => x.ID == id, cancellationToken).ConfigureAwait(false);
        }
    }
}
