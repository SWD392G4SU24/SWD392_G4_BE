using JewelrySalesSystem.Application.Common.Interfaces;
using JewelrySalesSystem.Application.Role.Update;
using MediatR;

namespace JewelrySalesSystem.Application.Counter.Update
{
    public class UpdateCounterCommand : IRequest<string>, ICommand
    {
        public UpdateCounterCommand(int id, string name)
        {
            ID = id;
            Name = name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
