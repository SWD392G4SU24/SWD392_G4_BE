using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Form.CreateForm
{
    public class CreateFormCommandValidator : AbstractValidator<CreateFormCommand>
    {
        public CreateFormCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.Content)
                .MaximumLength(255);
            RuleFor(x => x.Type)
                .NotNull().WithMessage("Type không được để trống")
                .Must(BeValidType).WithMessage("Type chỉ được nhập theo 3 dạng:EXCHANGE, MAINTENANCE, REFUND");
        }
        private bool BeValidType(FormType type)
        {
            return type.Equals(FormType.EXCHANGE) || type.Equals(FormType.MAINTENANCE) || type.Equals(FormType.REFUND);
        }
    }
}
