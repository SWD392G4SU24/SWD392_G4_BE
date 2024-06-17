﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.Note).NotEmpty().MaximumLength(255);
            RuleFor(x => x.TotalCost).NotEmpty();
            RuleFor(x => x.PaymentMethodID).NotEmpty();
            RuleFor(x => x.Type).NotEmpty();
            RuleFor(x => x.BuyerID).NotEmpty();

        }
    }
}
