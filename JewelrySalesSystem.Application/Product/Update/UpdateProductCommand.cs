using JewelrySalesSystem.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product.Update
{
    public class UpdateProductCommand : IRequest<string>, ICommand
    {
        public UpdateProductCommand(string name, string iD, float? goldWeight, int? goldID, int? diamondID, string? imageURL, int quantity, string? description, int categoryID)
        {
            Name = name;
            ID = iD;
            GoldWeight = goldWeight;
            GoldID = goldID;
            DiamondID = diamondID;
            ImageURL = imageURL;
            Quantity = quantity;
            Description = description;
            CategoryID = categoryID;
        }
        public string Name {  get; set; }
        public string ID { get; set; }
        public float? GoldWeight { get; set; }
        public int? GoldID { get; set; }
        public int? DiamondID { get; set; }
        public string? ImageURL { get; set; }
        public required int Quantity { get; set; }
        public string? Description { get; set; }
        public required int CategoryID { get; set; }
    }
}
