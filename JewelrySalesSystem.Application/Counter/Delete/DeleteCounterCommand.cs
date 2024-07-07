using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;

namespace JewelrySalesSystem.Application.Counter.Delete
{
    public class DeleteCounterCommand : IRequest<string>, ICommand
    {
        public DeleteCounterCommand(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}
