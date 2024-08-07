﻿using FluentValidation;
using JewelrySalesSystem.Application.Order.CustomerCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.StaffCreate
{
    public class CreateOrderByStaffCommandValidator : AbstractValidator<CreateOrderByStaffCommand>
    {
        public CreateOrderByStaffCommandValidator()
        {
            ConfigureValidationRule();
        }

        private void ConfigureValidationRule()
        {
            RuleFor(v => v.OrderDetails)
                .NotEmpty().WithMessage("Không có sản phẩm nào được đặt");
            RuleFor(v => v.PaymentMethodID)
                .NotNull().WithMessage("PaymentMethodID không được để trống");
            RuleFor(v => v.BuyerID)
                .NotEmpty().WithMessage("BuyerID không được để trống");
        }
    }
}
