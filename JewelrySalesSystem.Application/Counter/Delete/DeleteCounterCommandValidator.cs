using FluentValidation;

namespace JewelrySalesSystem.Application.Counter.Delete
{
    public class DeleteCounterCommandValidator : AbstractValidator<DeleteCounterCommand>
    {
        public DeleteCounterCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(x => x.ID).NotNull().NotEmpty().WithMessage("ID không được bỏ trống");
        }
    }
}
