using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.ExchangeVoucher
{
    public class ExchangeVoucherCommandValidator : AbstractValidator<ExchangeVoucherCommand>
    {
        public ExchangeVoucherCommandValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.VoucherContent).NotEmpty()
                .NotNull().MaximumLength(255)
                .WithMessage("Độ dài Description không được quá 255 ký tự");

        }
    }
}
