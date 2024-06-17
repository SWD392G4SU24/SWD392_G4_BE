using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.Create
{
    public class CreateOrderDetailCommandValidator : AbstractValidator<CreateOrderDetailCommand>
    {
        public CreateOrderDetailCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.ProductCost).NotEmpty();
            RuleFor(x => x.ProductID).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.OrderID).NotEmpty();
            
        }
    }
}
