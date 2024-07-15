using FluentValidation;
using JewelrySalesSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Form.UpdateStatus
{
    public class UpdateStatusFromCommandValidator : AbstractValidator<UpdateStatusFromCommand>
    {
        public UpdateStatusFromCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.FormID)
                .NotNull().WithMessage("ID không được để trống");

            RuleFor(x => x.Status)
                .NotNull().WithMessage("Status không được để trống")
                .Must(BeValidStatus).WithMessage("Status chỉ được nhập 2 loại:APPROVED, REJECTED");
       
        }
        
        private bool BeValidStatus(FormStatus status)
        {
            return status.Equals(FormStatus.APPROVED) || status.Equals(FormStatus.REJECTED);
        }

       }
}
