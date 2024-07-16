using FluentValidation;
using JewelrySalesSystem.Application.Users.CreateNewUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.CreatePromotion
{
    public class CreateProductCommandValidator : AbstractValidator<CreatePromtionCommand>
    {
        public CreateProductCommandValidator() {
            OnValidate();   
        }

        private void OnValidate()
        {
            RuleFor(x => x.ReducedPercent)
                .NotNull().WithMessage("ReducedPercent không được để trống")
                .GreaterThanOrEqualTo(1).WithMessage("ReducedPercent phải lớn hơn 0")
                .LessThan(100).WithMessage("ReducedPercent không được lớn hơn 100");

            RuleFor(x => x.ExpiresTime)
                .NotNull().WithMessage("ExpiresTime không được để trống")
                .Must(NotBeInPast).WithMessage("ExpiresTime không được là năm cũ");

            RuleFor(x => x.ConditionsOfUse)
                .NotNull().WithMessage("ConditionsOfUse không được để trống")
                .GreaterThanOrEqualTo(1).WithMessage("ConditionsOfUse không được bằng 0");

            RuleFor(x => x.MaximumReduce)
                .NotNull().WithMessage("MaximumReduce không được để trống")
                .GreaterThanOrEqualTo(1).WithMessage("MaximumReduce phải lớn hơn 0");
                
            RuleFor(x => x.ExchangePoint)
                .NotNull().WithMessage("ExchangePoint không được để trống")
                .GreaterThanOrEqualTo(1).WithMessage("ExchangePoint phải lớn hơn 0");

            RuleFor(x => x.Description).MaximumLength(255);
        }

        private bool NotBeInPast(DateTime time)
        {
            return time >= DateTime.Now;
        }
    }
}
