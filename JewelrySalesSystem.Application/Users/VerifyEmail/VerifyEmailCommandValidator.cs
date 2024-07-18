using FluentValidation;
using JewelrySalesSystem.Application.Users.VerifyAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.VerifyEmail
{
    public class VerifyEmailCommandValidator : AbstractValidator<VerifyEmailCommand>
    {
        public VerifyEmailCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Token)
                .NotEmpty().NotNull().WithMessage("Token không được để trống");
            RuleFor(v => v.UserID)
                .NotEmpty().NotNull().WithMessage("UserID không được để trống");
        }
    }
}
