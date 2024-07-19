using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.UpdatePromotion
{
    public class UpdatePromotionCommandValidator : AbstractValidator<UpdatePromotionCommand>
    {
        public UpdatePromotionCommandValidator()
        {
            OnValidate();
        }

        private void OnValidate()
        {
            RuleFor(x => x.ID)
                .NotNull().WithMessage("ID không được để trống");

            RuleFor(x => x.ReducedPercent)
                .NotNull().WithMessage("Phần trăm được giảm không được để trống")
                .GreaterThanOrEqualTo(1).WithMessage("Phần trăm được giảm phải lớn hơn 0")
                .LessThan(100).WithMessage("Phần trăm được giảm phải nhỏ hơn 100");

            RuleFor(x => x.ConditionsOfUse)
                .NotNull().WithMessage("Điều kiện sử dụng không được để trống")
                .GreaterThanOrEqualTo(0).WithMessage("Điều kiện sử dụng không được là số âm");

            RuleFor(x => x.MaximumReduce)
                .NotNull().WithMessage("Số tiền giảm tối đa không được để trống")
                .GreaterThanOrEqualTo(0).WithMessage("Số tiền giảm tối đa không được là số âm");          

            RuleFor(x => x.ExchangePoint)
                .NotNull().WithMessage("Điểm đổi không được để trống")
                .GreaterThanOrEqualTo(0).WithMessage("Điểm đổi không được là số âm");

            RuleFor(x => x.ExpiresTime)
                .Must(NotBeInPast).WithMessage("Thời gian hết hạn không hợp lệ");

            RuleFor(x => x.Description).MaximumLength(255);
        }
        private bool NotBeInPast(DateTime? time)
        {
            return time >= DateTime.Now;
        }
    }
}
