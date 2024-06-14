using FluentValidation;
using JewelrySalesSystem.Application.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Role.CreateRole
{
    public class CreateRoleCommandValidation : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidation() 
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.Name)
                .NotEmpty();
        }
    }
}
