using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.OrderDetail.Delete
{
    public class DeleteOrderDetailCommandValidator : AbstractValidator<DeleteOrderDetailCommand>
    {
        public DeleteOrderDetailCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.Id)
                .NotNull().WithMessage("ID không được để trống");
        }
    }
}
