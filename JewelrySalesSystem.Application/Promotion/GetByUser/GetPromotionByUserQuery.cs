using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetByUser
{
    public class GetPromotionByUserQuery : IRequest<List<PromotionByUserDto>>, IQuery
    {
        public GetPromotionByUserQuery() { }
        public GetPromotionByUserQuery(string userId)
        {
            UserId = userId;
        }
        public string UserId { get; set; }

    }
}
