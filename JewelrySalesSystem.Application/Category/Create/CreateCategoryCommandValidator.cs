using FluentValidation;

namespace JewelrySalesSystem.Application.Category.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
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
