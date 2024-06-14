using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.CreateRole
{
    public class CreateRoleCommand : IRequest<string>, ICommand
    {
        public CreateRoleCommand(string name)
        {

            Name = name;

        }
        public required string Name {  get; set; }
    }
}
