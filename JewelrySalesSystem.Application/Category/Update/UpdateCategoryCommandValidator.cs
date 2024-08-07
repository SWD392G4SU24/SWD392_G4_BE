﻿using FluentValidation;

namespace JewelrySalesSystem.Application.Category.Update
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tên không được để trống");
        }
    }
}
