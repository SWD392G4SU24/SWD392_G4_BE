using FluentValidation;
using Microsoft.IdentityModel.Tokens;
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
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID không được để trống");     
            
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).When(x => x.Quantity.HasValue).WithMessage("Số lượng không được là số âm");

            RuleFor(x => x.Description)
                .MaximumLength(255);
        }
    }
}
