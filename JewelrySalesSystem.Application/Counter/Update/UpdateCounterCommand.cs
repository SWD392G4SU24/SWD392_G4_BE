using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;

namespace JewelrySalesSystem.Application.Counter.Update
{
    public class UpdateCounterCommand : IRequest<string>, ICommand
    {
        public required int ID { get; set; }
        public required string Name { get; set; }
        public required int CategoryID { get; set; }
    }
}
