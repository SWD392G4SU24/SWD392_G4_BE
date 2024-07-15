using FluentValidation;
using JewelrySalesSystem.Application.Promotion.ExchangeVoucher;
using JewelrySalesSystem.Application.Promotion.GetByUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetUserByPagination
{
    public class GetUserByPaginationQueryValidator : AbstractValidator<GetUserByPaginationQuery>
    {
        public GetUserByPaginationQueryValidator()
        {
            Configure();
        }
        public void Configure()
        {
            RuleFor(x => x.PageSize).NotEmpty()
                 .NotNull()
                 .WithMessage("PageSize can't be null or empty");

            RuleFor(x => x.PageNumber).NotEmpty()
                .NotNull()
                .WithMessage("PageNumber can't be null or empty");
        }
    }
}
