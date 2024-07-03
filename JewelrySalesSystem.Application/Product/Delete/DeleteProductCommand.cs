using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product.Delete
{
    public class DeleteProductCommand : IRequest<string>, ICommand
    {
        public DeleteProductCommand(string iD)
        {
            ID = iD;
        }

        public  string ID {  get; set; }
    }
}
