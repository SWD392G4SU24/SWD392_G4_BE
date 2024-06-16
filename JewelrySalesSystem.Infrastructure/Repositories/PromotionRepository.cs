using AutoMapper;
using JewelrySalesSystem.Domain.Entities;
using JewelrySalesSystem.Domain.Repositories;
using JewelrySalesSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Infrastructure.Repositories
{
    public class PromotionRepository : RepositoryBase<PromotionEntity, PromotionEntity, ApplicationDbContext>, IPromotionRepository
    {
        private readonly ApplicationDbContext _context;
        public PromotionRepository(ApplicationDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
            _context =dbContext;
        }

        public async Task<IEnumerable<PromotionEntity>> GetAllPromotionsAsync(CancellationToken cancellationToken)
        {
            return await _context.Promotions.ToListAsync(cancellationToken).ConfigureAwait(false);  
        }


        public async Task<PromotionEntity> GetPromotionByIdAsnyc(Guid id, CancellationToken cancellationToken)
        {
            return await _context.Promotions.FindAsync(id.ToString(), cancellationToken);
        }

        public async Task UpdateAsnyc(PromotionEntity entity, CancellationToken cancellationToken)
        {
            _context.Promotions.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
