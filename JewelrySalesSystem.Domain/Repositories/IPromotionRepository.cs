﻿
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Domain.Repositories
{
    public interface IPromotionRepository : IEFRepository<PromotionEntity, PromotionEntity>
    {
        Task<IEnumerable<PromotionEntity>> GetAllPromotionsAsync(CancellationToken cancellationToken);
        Task<PromotionEntity>GetPromotionByIdAsnyc(string id, CancellationToken cancellationToken);
        
    }
}
