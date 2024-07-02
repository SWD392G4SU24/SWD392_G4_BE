using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product.Create
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.CategoryID)
                .NotEmpty();
            RuleFor(x => x.Quantity)
                .NotEmpty();
            RuleFor(x => x.Description)
                .MaximumLength(255);

        }
    }
}
