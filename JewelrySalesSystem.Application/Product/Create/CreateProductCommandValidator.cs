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
                .GreaterThanOrEqualTo(1).WithMessage("Quantity phải lớn hơn hoặc bằng 1");
            RuleFor(x => x.Description)
                .MaximumLength(255);
            RuleFor(x => x.GoldWeight)
                .GreaterThan(0)
                .When(x => x.GoldType != null)
                .WithMessage("GoldWeight phải lớn hơn 0 nếu sản phẩm có GoldType");
            RuleFor(x => x.GoldType)
                .NotNull()
                .When(x => x.DiamondType == null)
                .WithMessage("Sản phẩm cần phải tạo từ vàng, kim cương hoặc cả hai");
        }
    }
}
