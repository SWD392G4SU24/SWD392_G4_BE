using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.Delete
{
    public class DeleteRoleCommand : IRequest<string>, ICommand
    {
        public DeleteRoleCommand(int id)
        {
            ID = id;
        }
        public int ID { get; set; }
    }
}
