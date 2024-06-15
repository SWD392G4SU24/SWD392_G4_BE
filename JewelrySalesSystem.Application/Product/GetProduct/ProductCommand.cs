using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelrySalesSystem.Application.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelrySalesSystem.Application.Product.GetProduct
{
    public class ProductCommand : IRequest<string>, ICommand
    {
        public ProductCommand(decimal _WageCost, int _Quantity, int _CategoryID)
        {
            WageCost = _WageCost;
            Quantity = _Quantity;
            CategoryID = _CategoryID;

        }
        public required decimal WageCost { get; set; }
        public required int Quantity { get; set; }
        public required int CategoryID { get; set; }

    }
}
