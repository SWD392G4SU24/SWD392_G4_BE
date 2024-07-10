using FluentValidation;

namespace JewelrySalesSystem.Application.Category.Delete
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("ID không được để trống");
        }
    }
}
