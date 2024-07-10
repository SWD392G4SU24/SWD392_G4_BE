using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Counter.CreateCounter;
using MediatR;

namespace JewelrySalesSystem.Application.Counter.GetById
{
    public class GetCounterByIdQuery : IRequest<CounterDto>, IQuery
    {
        public GetCounterByIdQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
