using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(x => x.Password)
                .MinimumLength(6).WithMessage("Password must contain 6 characters");
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Email is not correct format");
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(12).WithMessage("Phone number must contain 10-12 numbers")
                .MinimumLength(10).WithMessage("Phone number must contain 10-12 numbers");
        }
    }
}
