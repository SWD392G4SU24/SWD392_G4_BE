using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Users.AssignStaff
{
    public class AssignStaffCommandValidator : AbstractValidator<AssignStaffCommand>
    {
        public AssignStaffCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(x => x.StaffID)
                .NotEmpty().WithMessage("StaffID không được để trống");

            RuleFor(x => x.CounterID)
                .NotEmpty().NotNull().WithMessage("CounterID không được để trống");
        }
    }
}
