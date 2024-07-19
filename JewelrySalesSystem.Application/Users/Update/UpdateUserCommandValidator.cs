using FluentValidation;
using Microsoft.IdentityModel.Tokens;
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
                .MinimumLength(6).WithMessage("Mật khẩu phải có ít nhất 6 ký tụ");
            RuleFor(x => x.Email)
                .EmailAddress().When(x => !x.Email.IsNullOrEmpty()).WithMessage("Email không đúng format");
            RuleFor(x => x.PhoneNumber)
                .MaximumLength(12).WithMessage("Số điện thoại bao gồm 10-12 số")
                .MinimumLength(10).WithMessage("Số điện thoại bao gồm 10-12 số");
        }
    }
}
