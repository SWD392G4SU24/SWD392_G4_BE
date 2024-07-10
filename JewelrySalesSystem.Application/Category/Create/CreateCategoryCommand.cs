using MediatR;
using JewelrySalesSystem.Application.Common.Interfaces;

namespace JewelrySalesSystem.Application.Category.Create
{
    public class CreateCategoryCommand : IRequest<string>, ICommand
    {
        public CreateCategoryCommand(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
