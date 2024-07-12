using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Form.Delete
{
    public class DeleteFormCommand : IRequest<string>, ICommand
    {
        public DeleteFormCommand(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
