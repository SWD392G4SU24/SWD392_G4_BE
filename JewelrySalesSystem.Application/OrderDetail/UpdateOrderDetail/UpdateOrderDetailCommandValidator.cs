using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.UpdateOrderDetail
{
    public class UpdateOrderDetailCommandValidator : AbstractValidator<UpdateOrderDetailCommand>
    {
        public UpdateOrderDetailCommandValidator() 
        {
            ConfigureValidationRules();
        }

        private void ConfigureValidationRules()
        {
            RuleFor(v => v.Quantity)
                .GreaterThan(0).WithMessage("Số lượng phải lớn hơn 0")
                .NotNull().WithMessage("Số lượng không được để NULL");
            RuleFor(v => v.ProductID)
                .NotNull().WithMessage("ProductID không được NULL")
                .NotEmpty().WithMessage("ProductID không được để trống");
        }
    }
}
