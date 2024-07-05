using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JewelrySalesSystem.Application.Common.Interfaces;

namespace JewelrySalesSystem.Application.Product.Create
{
    public class CreateProductCommand : IRequest<string>, ICommand
    {
        public CreateProductCommand(string name, float? goldWeight, int? goldType, int? diamondType, string? imageURL, int quantity, string? description, int categoryID)
        {
            Name = name;
            GoldWeight = goldWeight;
            GoldType = goldType;
            DiamondType = diamondType;
            ImageURL = imageURL;
            Quantity = quantity;
            Description = description;
            CategoryID = categoryID;
        }

        public string Name {  get; set; }
        public float? GoldWeight { get; set; }
        public int? GoldType { get; set; }
        public int? DiamondType { get; set; }
        public string? ImageURL { get; set; }
        public required int Quantity { get; set; }
        public string? Description { get; set; }
        public required int CategoryID { get; set; }
    }
}
