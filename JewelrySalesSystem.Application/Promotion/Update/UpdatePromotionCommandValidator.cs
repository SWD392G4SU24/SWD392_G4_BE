using FluentValidation;
using Microsoft.IdentityModel.Tokens;
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
            .GreaterThanOrEqualTo(1).When(x => x.ReducedPercent.HasValue).WithMessage("Phần trăm được giảm phải lớn hơn 0")
            .LessThan(100).When(x => x.ReducedPercent.HasValue).WithMessage("Phần trăm được giảm phải nhỏ hơn 100");

            RuleFor(x => x.ConditionsOfUse)
                .GreaterThanOrEqualTo(0).When(x => x.ConditionsOfUse.HasValue).WithMessage("Điều kiện sử dụng không được là số âm");

            RuleFor(x => x.MaximumReduce)
                .GreaterThanOrEqualTo(0).When(x => x.MaximumReduce.HasValue).WithMessage("Số tiền giảm tối đa không được là số âm");

            RuleFor(x => x.ExchangePoint)              
                .GreaterThanOrEqualTo(0).When(x => x.ExchangePoint.HasValue).WithMessage("Điểm đổi không được là số âm");

            RuleFor(x => x.ExpiresTime)
                .Must(NotBeInPast).When(x => x.ExpiresTime.HasValue).WithMessage("Thời gian hết hạn không hợp lệ");

            RuleFor(x => x.Description)
                .MaximumLength(255);
        }
        private bool NotBeInPast(DateTime? time)
        {
            return time >= DateTime.Now;
        }
    }
}
