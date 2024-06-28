using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.Update
{
    public class UpdateRoleCommandValidator : AbstractValidator<UpdateRoleCommand>
    {
        public UpdateRoleCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name không được để trống");
        }
    }
}
