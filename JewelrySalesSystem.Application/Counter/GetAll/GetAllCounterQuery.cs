using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using MediatR;
using System.Collections.Generic;

namespace JewelrySalesSystem.Application.Counter.GetAll
{
    public class GetAllCounterQuery : IRequest<List<CounterDto>>, IQuery
    {
    }
}
