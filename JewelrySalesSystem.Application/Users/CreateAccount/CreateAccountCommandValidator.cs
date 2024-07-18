using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.CreateAccount
{
    public class CreateAccountCommandValidator : AbstractValidator<CreateAccountCommand>
    {
        public CreateAccountCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.Email)
                .NotEmpty().EmailAddress();

            RuleFor(x => x.Address)
                .NotEmpty();

            RuleFor(x => x.PhoneNumber)
                .NotEmpty();

            RuleFor(x => x.Username)
                .NotEmpty();

            RuleFor(x => x.FullName)
                .NotEmpty();

            RuleFor(x => x.RoleID)
                .NotEmpty().NotNull();
        }
    }
}
