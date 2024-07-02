using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Product.Update
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
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
