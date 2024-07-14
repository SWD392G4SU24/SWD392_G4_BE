using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.CustomerCreate
{
    public class CreateOrderByCustomerCommandValidator : AbstractValidator<CreateOrderByCustomerCommand>
    {
        public CreateOrderByCustomerCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(v => v.OrderDetails)
                .NotEmpty().WithMessage("Không có sản phẩm nào được đặt");
        }
    }
}
