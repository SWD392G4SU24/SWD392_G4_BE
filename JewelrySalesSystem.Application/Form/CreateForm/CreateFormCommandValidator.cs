using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JewelrySalesSystem.Domain.Commons.Enums.Enums;

namespace JewelrySalesSystem.Application.Form.CreateForm
{
    public class CreateFormCommandValidator : AbstractValidator<CreateFormCommand>
    {
        public CreateFormCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.Content)
                .MaximumLength(255);
            RuleFor(x => x.AppointmentDate)
                .NotNull().WithMessage("AppointmentDate không được để trống");
            RuleFor(x => x.AppointmentDate)
                .Must(NotBeInPast).WithMessage("AppointmentDate không được là năm cũ hay cùng ngày tháng năm");
            RuleFor(x => x.TypeString)
                .NotNull().WithMessage("TypeString không được để trống");
            RuleFor(x => x.TypeString).
                Must(BeValidTypeString).WithMessage("Type chỉ được nhập theo 3 dạng:EXCHANGE, MAINTENANCE, REFUND");
        }
        private bool NotBeInPast(DateTime time)
        {
            return time >= DateTime.Now;
        }
        private bool BeValidType(FormType type)
        {
            return type.Equals(FormType.EXCHANGE) || type.Equals(FormType.MAINTENANCE) || type.Equals(FormType.REFUND);
        }

        private bool BeValidTypeString(string typeString)
        {
            // Kiểm tra xem typeString có thể parse thành FormType và hợp lệ
            if (Enum.TryParse(typeString, true, out FormType result))
            {
                return BeValidType(result);
            }
            return false;
        }
    }
}
