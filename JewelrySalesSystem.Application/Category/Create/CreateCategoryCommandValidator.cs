using FluentValidation;

namespace JewelrySalesSystem.Application.Category.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
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
