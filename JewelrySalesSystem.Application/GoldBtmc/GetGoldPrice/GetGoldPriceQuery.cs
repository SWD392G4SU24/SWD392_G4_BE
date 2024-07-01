using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Domain.Entities.Configured;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.GoldBtmc.GetGoldPrice
{
    public class GetGoldPriceQuery : IRequest<List<GoldDto>>, IQuery
    {
    }
}
