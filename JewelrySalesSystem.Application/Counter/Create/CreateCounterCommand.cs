using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;

namespace JewelrySalesSystem.Application.Counter.CreateCounter
{
    public class CreateCounterCommand : IRequest<string>, ICommand
    {
        public CreateCounterCommand(string name, int categoryId)
        {
            Name = name;
            CategoryID = categoryId;
        }

        public required string Name { get; set; }
        public required int CategoryID { get; set; }
    }
}
