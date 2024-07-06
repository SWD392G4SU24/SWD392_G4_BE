using FluentValidation;

namespace JewelrySalesSystem.Application.Category.Delete
{
    public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("ID không được để trống");
        }
    }
}
