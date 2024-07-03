using FluentValidation;
using JewelrySalesSystem.Application.Promotion.DeletePromotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.Delete
{
    public class DeletePromotionCommandValidator : AbstractValidator<DeletePromotionCommand>
    {
        public DeletePromotionCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID không được để trống");
        }
    }
}
