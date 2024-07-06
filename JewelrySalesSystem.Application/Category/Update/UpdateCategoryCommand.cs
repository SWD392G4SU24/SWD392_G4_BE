using MediatR;
using JewelrySalesSystem.Application.Common.Interfaces;

namespace JewelrySalesSystem.Application.Category.Update
{
    public class UpdateCategoryCommand : IRequest<string>, ICommand
    {
        public UpdateCategoryCommand(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
