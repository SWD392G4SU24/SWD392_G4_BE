using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.Create
{
    public class CreateDiamonCommand : IRequest<string>, ICommand
    {
        public CreateDiamonCommand(decimal buyCost, decimal sellCost, string name)
        {
            BuyCost = buyCost;
            SellCost = sellCost;
            Name = name;
        }
        public required string Name { get; set; }
        public required decimal BuyCost { get; set; }
        public required decimal SellCost { get; set; }
    }
}
