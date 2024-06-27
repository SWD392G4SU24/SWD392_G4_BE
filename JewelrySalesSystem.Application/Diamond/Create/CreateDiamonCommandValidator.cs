using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Diamon.Create
{
    public class CreateDiamonCommandValidator : AbstractValidator<CreateDiamonCommand>
    {
        public CreateDiamonCommandValidator()
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
