using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Form.Update
{
    public class UpdateFormCommandValidator : AbstractValidator<UpdateFormCommand>
    {
        public UpdateFormCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.FormID)
                .NotNull().WithMessage("ID không được để trống");

            RuleFor(x => x.Content)
                .MaximumLength(255);

            RuleFor(x => x.AppointmentDate)               
                .Must(NotBeInPast).WithMessage("AppointmentDate không được là năm cũ hay cùng ngày tháng năm");
          
        }
        private bool NotBeInPast(DateTime? time)
        {
            return time >= DateTime.Now;
        }
    }
}
