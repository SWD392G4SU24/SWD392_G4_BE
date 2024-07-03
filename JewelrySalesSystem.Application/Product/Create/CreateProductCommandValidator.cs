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
                .NotEmpty().WithMessage("CatergoryID không được để trống");
            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Vui lòng nhập số lượng");
            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(1).WithMessage("Quantity phải lớn hơn hoặc bằng 1");
            RuleFor(x => x.Description)
                .MaximumLength(255);
        }
    }
}
