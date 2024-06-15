using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetAll
{
    public class GetAllPromotionsQuery : IRequest<IEnumerable<PromotionDto>>, IQuery
    {
        public GetAllPromotionsQuery()
        {
            
        }
    }
}
