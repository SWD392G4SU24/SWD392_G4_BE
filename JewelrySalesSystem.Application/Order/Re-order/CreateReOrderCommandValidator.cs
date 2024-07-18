using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.Re_order
{
    public class CreateReOrderCommandValidator :AbstractValidator<CreateReOrderCommand>
    {
        public CreateReOrderCommandValidator()
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Quantity)
                .NotNull().GreaterThan(0).When(x => !string.IsNullOrEmpty(x.OrderDetailID)).WithMessage("Số lượng phải lớn hơn 0 nếu có hóa đơn");
            
            RuleFor(v => v.CustomerID)
                .NotEmpty().WithMessage("ID khách hàng không được để trống")
                .NotNull().WithMessage("CustomerID không được NULL");

            RuleFor(v => v.GoldWeight)
                .NotNull().GreaterThan(0).When(x => string.IsNullOrEmpty(x.OrderDetailID)).WithMessage("Lượng vàng phải lớn hơn 0 nếu không có hóa đơn");
            
            RuleFor(v => v.GoldType)
                .NotNull().NotEmpty().When(x => string.IsNullOrEmpty(x.OrderDetailID)).WithMessage("Loại vàng không được để trống nếu không có hóa đơn");
        }
    }
}
