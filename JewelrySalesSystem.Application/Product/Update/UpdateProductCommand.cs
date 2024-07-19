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
        public UpdateProductCommand(string? name
            , string id, float? goldWeight, string? goldType
            , string? diamondType
            , string? imageURL
            , int? quantity
            , string? description
            , int? categoryID)
        {
            Name = name;
            ID = id;
            GoldWeight = goldWeight;
            GoldType = goldType;
            DiamondType = diamondType;
            ImageURL = imageURL;
            Quantity = quantity;
            Description = description;
            CategoryID = categoryID;
        }
        public UpdateProductCommand()
        {
            
        }
        public string? Name {  get; set; }
        public string ID { get; set; }
        public float? GoldWeight { get; set; }
        public string? GoldType { get; set; }
        public string? DiamondType { get; set; }
        public string? ImageURL { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        public int? CategoryID { get; set; }
    }
}
