using MediatR;
using JewelrySalesSystem.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetPromotion
{
    public class GetPromotionsQuery : IRequest<IEnumerable<PromotionDto>>, IQuery
    {
        public string Category { get; set; }
        public DateTime ExpiresTime { get; set; }
    }
}
