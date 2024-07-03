using FluentValidation;
using JewelrySalesSystem.Application.Order.DeleteOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Order.Delete
{
    public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrdercommand>
    {
        public DeleteOrderCommandValidator()
        {
            OnValidate();
        }

        private  void OnValidate()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("ID không được để trống");
        }
    }
}
