﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelrySalesSystem.Application.Promotion.GetByPagination
{
    public class GetPromotionByPaginationQueryValidator : AbstractValidator<GetPromotionByPaginationQuery>
    {
        public GetPromotionByPaginationQueryValidator()
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
