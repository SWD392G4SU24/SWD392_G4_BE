using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetById
{
    public class GetByIDQuery : IRequest<IEnumerable<PromotionDto>>, IQuery
    {
        public required Guid Id { get; set; }
    }
}
