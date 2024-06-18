using FluentValidation;
using JewelrySalesSystem.Application.Diamon.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.Update
{
    public class UpdateDiamonCommandValidator : AbstractValidator<CreateDiamonCommand>
    {
        public UpdateDiamonCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.SellCost).NotEmpty();
            RuleFor(x => x.BuyCost).NotEmpty();
        }
    }
}
