using FluentValidation;

namespace JewelrySalesSystem.Application.Counter.CreateCounter
{
    public class CreateCounterCommandValidator : AbstractValidator<CreateCounterCommand>
    {
        public CreateCounterCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name không được để trống");
            RuleFor(x => x.CategoryID).NotNull().WithMessage("CategoryID không được để trống");
        }
    }
}
