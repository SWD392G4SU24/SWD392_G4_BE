using FluentValidation;

namespace JewelrySalesSystem.Application.Counter.Update
{
    public class UpdateCounterCommandValidator : AbstractValidator<UpdateCounterCommand>
    {
        public UpdateCounterCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name không được để trống");
        }
    }
}
