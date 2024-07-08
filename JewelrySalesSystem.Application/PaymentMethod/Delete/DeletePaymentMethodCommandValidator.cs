using FluentValidation;
using JewelrySalesSystem.Application.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.PaymentMethod.Delete
{
    public class DeletePaymentMethodCommandValidator : AbstractValidator<DeletePaymentMethodCommand>
    {
        public DeletePaymentMethodCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID không được để trống");
        }
    }
}
