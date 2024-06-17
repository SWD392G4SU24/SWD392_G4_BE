using FluentValidation;
using JewelrySalesSystem.Application.Users.CreateNewUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.CreatePromotion
{
    public class CreateProductCommandValidator : AbstractValidator<CreatePromtionCommand>
    {
        public CreateProductCommandValidator() {
            OnValidate();   
        }

        private void OnValidate()
        {
            RuleFor(x => x.ReducedPercent).NotEmpty();
            RuleFor(x => x.ExpiresTime).NotEmpty();
            RuleFor(x => x.ConditionsOfUse).NotEmpty();
            RuleFor(x => x.MaximumReduce).NotEmpty();
            RuleFor(x => x.ExchangePoint).NotEmpty();
            RuleFor(x => x.Description).MaximumLength(255);
        }
    }
}
